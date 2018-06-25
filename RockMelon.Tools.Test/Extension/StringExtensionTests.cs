using System;
using NUnit.Framework;
using RockMelon.Tools.Extension;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RockMelon.Tools.Test.Extension
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void ToMyString_TestString_ReturnTestString()
        {
            object sValue = "testString";
            Assert.AreEqual("testString", sValue.ToMyString());
        }

        [Test]
        public void ToMyString_EmptyString_ReturnEmptyString()
        {
            object sValue = "";
            Assert.AreEqual("", sValue.ToMyString());
        }

        [Test]
        public void ToMyString_NullString_ReturnEmptyString()
        {
            object sValue = null;
            Assert.AreEqual("", sValue.ToMyString());
        }

        //WordCount
        [Test]
        public void WordCount_SixWordsString_ReturnSix()
        {
            object sValue = "This is a six word sentence";
            Assert.AreEqual(6, sValue.WordCount());
        }

        [Test]
        public void WordCount_OneWordString_ReturnOne()
        {
            object sValue = "This";
            Assert.AreEqual(1, sValue.WordCount());
        }

        [Test]
        public void WordCount_OneWordWithSpaceString_ReturnOne()
        {
            object sValue = "This ";
            Assert.AreEqual(1, sValue.WordCount());
        }

        [Test]
        public void WordCount_OneWordWithTwoSpaceString_ReturnOne()
        {
            object sValue = " This ";
            Assert.AreEqual(1, sValue.WordCount());
        }

        [Test]
        public void WordCount_Null_ReturnZero()
        {
            object sValue = null;
            Assert.AreEqual(0, sValue.WordCount());
        }

        [Test]
        public void WordCount_EmptyString_ReturnZero()
        {
            object sValue = "";
            Assert.AreEqual(0, sValue.WordCount());
        }

        [Test]
        public void WordCount_EmptyStringWithSpace_ReturnZero()
        {
            object sValue = " ";
            Assert.AreEqual(0, sValue.WordCount());
        }

        [Test]
        public void WordCount_EmptyStringWithTwoSpace_ReturnZero()
        {
            object sValue = "  ";
            Assert.AreEqual(0, sValue.WordCount());
        }

        [Test]
        public void WordCount_RandomValue_ReturnZero()
        {
            object sValue = -1;
            Assert.AreEqual(1, sValue.WordCount());
        }

        //Split
        [Test]
        public void Split_TwoWordString_ReturnArrayWithTwoElements()
        {
            object str = "test;String";
            Assert.AreEqual(2, str.TheSplit(';').Length);
        }

        [Test]
        public void Split_OneWordString_ReturnArrayWithOneElements()
        {
            object str = "String";
            Assert.AreEqual(1, str.TheSplit(';').Length);
        }

        [Test]
        public void Split_NullString_ReturnArrayWithZeroElements()
        {
            object str = null;
            Assert.AreEqual(0, str.TheSplit(';').Length);
        }

        [Test]
        public void Split_TwoWordString_DifferentChar_ReturnArrayWithZeroElements()
        {
            object str = "test;String";
            var d = str.TheSplit(',');
            Assert.AreEqual(1, d.Length);
        }

        //Email
        [Test]
        public void IsValidEmailAddress_TwoValid_TwoCorrect()
        {
            Assert.IsTrue("yellowdog@someemail.uk".IsValidEmailAddress());
            Assert.IsTrue("yellow.444@email4u.co.uk".IsValidEmailAddress());
        }

        [Test]
        public void IsValidEmailAddress_TwoInValid_TwoFails()
        {
            Assert.IsFalse("adfasdf".IsValidEmailAddress());
            Assert.IsFalse("asd@asdf".IsValidEmailAddress());
        }

        //RemoveWhiteSpace
        [Test]
        public void RemoveWhiteSpace_SixWordSentence_ReturnStringWithNoSpace()
        {
            var str = "This is a six string sentence";
            Assert.IsFalse(str.RemoveWhiteSpace().Contains(" "));
        }

        [Test]
        public void RemoveWhiteSpace_NullSentence_ReturnEmptyString()
        {
            object str = null;
            Assert.IsTrue(String.IsNullOrEmpty(str.RemoveWhiteSpace()));
        }

        [Test]
        public void RemoveWhiteSpace_StringWithSpace_ReturnEmptyString()
        {
            object str = " ";
            Assert.IsTrue(String.IsNullOrEmpty(str.RemoveWhiteSpace()));
        }

        //IsNumber
        [Test]
        public void IsNumber_NumberChar_ReturnTrue()
        {
            object str = "2";
            Assert.IsTrue(str.IsNumber());
        }

        [Test]
        public void IsNumber_LetterChar_ReturnFalse()
        {
            object str = "X";
            Assert.IsFalse(str.IsNumber());
        }

        [Test]
        public void IsNumber_NullChar_ReturnFalse()
        {
            object str = null;
            Assert.IsFalse(str.IsNumber());
        }

        [Test]
        public void IsNumber_DoubleChar_ReturnTrue()
        {
            object str = 1.2;
            Assert.IsTrue(str.IsNumber());
        }

        //ToMD5
        [Test]
        public void ToMD5_PassSentence_ReturnCorrectEncryption()
        {
            string input = "The quick brown fox jumps over the lazy dog";
            string expected = "9e107d9d372bb6826bd81d3542a419d6";
            string actual = input.ToMD5();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToMD5_PassIncorrectSentence_ReturnInCorrectEncryption()
        {
            string input = "The quickXXX brown fox jumps over the lazy dog";
            string expected = "9e107d9d372bb6826bd81d3542a419d6";
            string actual = input.ToMD5();
            Assert.AreNotEqual(expected, actual);
        }

        //NlToBreak
        [Test]
        public void NlToBreak_ReturnStringWithBreaks()
        {
            string input = "yellow dog" + Environment.NewLine + "black cat";
            string expected = "yellow dog<br />black cat";
            string actual = input.NlToBreak();
            Assert.AreEqual(expected, actual);
        }

        //encryption
        [Test]
        public void Encrypt_PassString_Decrypt()
        {
            var str = "this string will be encrypted";
            var encryptedString = str.Encrypt("pp for encryption");
            Assert.IsNotNull(encryptedString);
            var decryptedString = encryptedString.Decrypt("pp for encryption");
            Assert.AreEqual(str, decryptedString);
        }

        [Test]
        public void Encrypt_PassString_IncorrectPassPhrase_NotEncrypted()
        {
            var str = "this string will be encrypted";
            var encryptedString = str.Encrypt("pp for encryption");
            var decryptedString = encryptedString.Decrypt("wrong pp for encryption");
            Assert.AreNotEqual(str, decryptedString);
        }
    }
}
