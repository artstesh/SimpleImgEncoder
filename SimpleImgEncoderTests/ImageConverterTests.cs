using System.Collections.Generic;
using System.Drawing;
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
    }
}