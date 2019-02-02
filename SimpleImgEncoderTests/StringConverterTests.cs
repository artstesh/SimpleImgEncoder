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
    }
}