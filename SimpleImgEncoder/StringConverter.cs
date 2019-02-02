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

        public string GetText(List<bool> bools)
        {
            var temp = BoolsToString(bools);
            var chars = BinaryStringToNumber(temp);
            var result = new string(chars.Select(e => (char) e).ToArray());
            return result;
        }

        public List<string> BoolsToString(List<bool> list)
        {
            var result = new List<string>();
            for (var i = 0; i < list.Count; )
            {
                var temp = String.Empty;
                for (int j = 0; j < 8; j++) temp += list[i++] ? "1" : "0";
                result.Add(temp);
            }
            return result;
        }
        
        public List<int> BinaryStringToNumber(List<string> binary)
        {
            return binary.Select(e => Convert.ToInt32(e, 2)).ToList();
        }
    }
}