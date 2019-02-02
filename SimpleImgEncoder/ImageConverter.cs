using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace SimpleImgEncoder
{
    public class ImageConverter
    {
        public Bitmap GetImage(List<bool> list)
        {
            var size = GetImageSize(list.Count);
            var count = 0;
           var map = new Bitmap(size,size,PixelFormat.Format24bppRgb);
               for (int j = 0; j < size; j++)
               {
                   for (int i = 0; i < size; i++)
                   {
                       map.SetPixel(j, i, list[count++] ? Color.Black : Color.White);
                   }   
               }
           return map;
        }

        public int GetImageSize(int listSize)
        {
            for (int i = listSize; i <= listSize*listSize; i++)
                if (Math.Abs(Math.Sqrt(i) % 1) < 0.00001)
                    return i;
            return -1;
        }
    }
}