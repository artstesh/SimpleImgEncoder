using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NUnit.Framework;
using ImageConverter = SimpleImgEncoder.ImageConverter;

namespace SimpleImgEncoderTests
{
    public class ImageConverterTests
    {
        [TestCase(1, 1)]
        [TestCase(7, 9)]
        [TestCase(12, 16)]
        public void GetImageSize_Success(int input, int expected)
        {
            var converter = new ImageConverter();
            var result = converter.GetImageSize(input);
            Assert.IsTrue(result == expected);
        }
        
        
        [Test]
        public void GetImage_Success_White()
        {
            var list = new List<bool> { false};
            var converter = new ImageConverter();
            var result = converter.GetImage(list);
            var pixel = result.GetPixel(0,0);
            Assert.IsTrue(pixel.A ==  Color.White.A);
            Assert.IsTrue(pixel.B ==  Color.White.B);
            Assert.IsTrue(pixel.R ==  Color.White.R);
            Assert.IsTrue(pixel.G ==  Color.White.G);
        }
        
        [Test]
        public void GetImage_Success_Black()
        {
            var list = new List<bool> { true};
            var converter = new ImageConverter();
            var result = converter.GetImage(list);

            var pixel = result.GetPixel(0,0);
            Assert.IsTrue(pixel.A ==  Color.Black.A);
            Assert.IsTrue(pixel.B ==  Color.Black.B);
            Assert.IsTrue(pixel.R ==  Color.Black.R);
            Assert.IsTrue(pixel.G ==  Color.Black.G);
        }
        
        [Test]
        public void GetImage_Success_Orientation()
        {
            var list = new List<bool> { true, false, true, false};
            var converter = new ImageConverter();
            var result = converter.GetImage(list);

            var pixel00 = result.GetPixel(0,0);
            var pixel10 = result.GetPixel(1,0);
            var pixel01 = result.GetPixel(0,1);
            Assert.IsTrue(pixel00.G ==  Color.Black.G);
            Assert.IsTrue(pixel10.G ==  Color.White.G);
            Assert.IsTrue(pixel01.G ==  Color.Black.G);
        }
        
        [Test]
        public void GetImage_Success_FInal()
        {
            var list = new List<bool> { true, false, true};
            var converter = new ImageConverter();
            var result = converter.GetImage(list);
            var pixel = result.GetPixel(1,1);
            Assert.IsTrue(pixel.G ==  Color.Blue.G);
        }

        [Test]
        public void GetImage_Success_Size()
        {
            var list = new List<bool> { true, false, true, false };
            var converter = new ImageConverter();
            var result = converter.GetImage(list);
            Assert.IsTrue(result.Size.Height == 2);
        }
        
        [Test]
        public void GetInts_Success_White()
        {
            var list = new List<bool> { false};
            var map = new Bitmap(1,1);
            map.SetPixel(0,0,Color.White);
            //
            var converter = new ImageConverter();
            
            var result = converter.GetInts(map);
            Assert.IsTrue(result.SequenceEqual(list));
        }
        
        [Test]
        public void GetInts_Success_Black()
        {
            var list = new List<bool> { true};
            var map = new Bitmap(1,1);
            map.SetPixel(0,0,Color.Black);
            //
            var converter = new ImageConverter();
            
            var result = converter.GetInts(map);
            Assert.IsTrue(result.SequenceEqual(list));
        }
    }
}