using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace SimpleImgEncoder
{
    public class ImageConverter : IImageConverter
    {
        public Bitmap GetImage(List<bool> list)
        {
            var size = GetImageSize(list.Count);
            var side = (int) Math.Sqrt(size);
            var count = 0;
            var map = new Bitmap(side, side, PixelFormat.Format24bppRgb);
            for (int j = 0; j < side; j++)
            for (int i = 0; i < side; i++)
            {
                if (count >= list.Count)
                    map.SetPixel(i, j, Color.Blue);
                else
                {
                    var color = list[count++] ? Color.Black : Color.White;
                    map.SetPixel(i, j, color);
                }
            }
            return map;
        }

        public int GetImageSize(int listSize)
        {
            for (int i = listSize; i <= listSize * listSize; i++)
                if (Math.Abs(Math.Sqrt(i) % 1) < 0.00001)
                    return i;
            return -1;
        }
        
        public List<bool> GetInts(Bitmap bitmap)
        {
            var side = bitmap.Size.Width;
            var count = 0;
            var result = new List<bool>();
            for (int j = 0; j < side; j++)
            for (int i = 0; i < side; i++)
            {
                var pixel = bitmap.GetPixel(i, j);
                if (Color.Blue.ToArgb().Equals(pixel.ToArgb()))
                    return result;
                var res = Color.Black.ToArgb().Equals(pixel.ToArgb());
                result.Add(res);
            }
            return result;
        }
    }
}