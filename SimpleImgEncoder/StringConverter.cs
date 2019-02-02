using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleImgEncoder
{
    public class StringConverter : IStringConverter
    {
        public IEnumerable<bool> GetInts(string text)
        {
            var chars = GetNumbers(text);
            string[] strBinaries = NumberToBinaryString(chars);
            return StringToBools(strBinaries);
        }

        public List<bool> StringToBools(string[] strBinaries)
        {
            var result = new List<bool>();
            foreach (var strBinary in strBinaries) result.AddRange(strBinary.Select(e => e == '1'));
            return result;
        }

        public string[] NumberToBinaryString(int[] chars)
        {
            return chars.Select(e => Convert.ToString(e, 2).PadLeft(8,'0')).ToArray();
        }

        public int[] GetNumbers(string text)
        {
            return text.ToCharArray().Select(e => (int) e).ToArray();
        }

        public string GetText(List<int> text)
        {
            throw new System.NotImplementedException();
        }
    }
}