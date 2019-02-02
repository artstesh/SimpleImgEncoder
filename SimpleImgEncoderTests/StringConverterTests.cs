using System;
using System.Collections.Generic;
using System.Linq;
using SimpleImgEncoder;
using NUnit.Framework;

namespace SimpleImgEncoderTests
{
    [TestFixture]
    public class StringConverterTests
    {
        [Test]
        public void GetInts_Success()
        {
            var text = "0";
            var expected = new List<bool> { false,false,true,true,false,false,false,false};
            //
            var converter = new StringConverter();
            var result = converter.GetInts(text);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [TestCase("0", 48)]
        public void GetNumbers_Success(string text, params int[] expected)
        {
            //
            var converter = new StringConverter();
            var result = converter.GetNumbers(text);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [TestCase("00110000", 48)]
        public void NumberToBinaryString_Success(string expected, params int[] input)
        {
            //
            var converter = new StringConverter();
            var result = converter.NumberToBinaryString(input);
            Assert.True(expected.Equals(result[0]));
        }
        
        [TestCase("0", false)]
        [TestCase("1", true)]
        [TestCase("010", false, true, false)]
        public void StringToBools_Success(string input, params bool[] expected)
        {
            var array = new string[] {input};
            //
            var converter = new StringConverter();
            var result = converter.StringToBools(array);
            Assert.True(expected.SequenceEqual(result));
        }
      
        
        [TestCase("10001100", true, false, false, false,true, true, false, false)]
        [TestCase("01100001", false, true, true, false,false, false, false, true)]
        [TestCase("00000111", false, false, false, false,false, true, true, true)]
        public void BoolsToString_Success(string expected, params bool[] input)
        {
            var inputList = new List<bool>();
            inputList.AddRange(input);
            //
            var converter = new StringConverter();
            var result = converter.BoolsToString(inputList);
            Assert.True(expected == result.First());
        }
        
        [TestCase("00110000", 48)]
        [TestCase("00000111", 7)]
        public void NumberToBinaryString_Success(string input, int expected)
        {
            var inputList = new List<string> {input};
            //
            var converter = new StringConverter();
            var result = converter.BinaryStringToNumber(inputList);
            Assert.True(expected == result.First());
        }
        
        [TestCase("A", false,true,false,false,false,false,false,true)]
        public void GetText_Success(string expected, params bool[] input)
        {
            var inputList = new List<bool>();
            inputList.AddRange(input);
            //
            var converter = new StringConverter();
            var result = converter.GetText(inputList);
            Assert.True(expected.SequenceEqual(result));
        }
    }
}