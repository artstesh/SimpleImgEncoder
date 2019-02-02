using System.Collections.Generic;

namespace SimpleImgEncoder
{
    public interface IStringConverter
    {
        IEnumerable<bool> GetInts(string text);
        string GetText(List<int> text);
        int[] GetNumbers(string text);
        string[] NumberToBinaryString(int[] chars);
        List<bool> StringToBools(string[] strBinaries);
    }
}