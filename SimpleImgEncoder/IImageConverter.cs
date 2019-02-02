using System.Collections.Generic;
using System.Drawing;

namespace SimpleImgEncoder
{
    public interface IImageConverter
    {
        Bitmap GetImage(List<bool> list);
        int GetImageSize(int listSize);
    }
}