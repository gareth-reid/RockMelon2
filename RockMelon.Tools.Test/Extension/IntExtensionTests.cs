using System;
using System.Diagnostics;
using NUnit.Framework;
using RockMelon.Tools.Extension;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RockMelon.Tools.Test.Extension
{
    [TestFixture]
    public class IntExtensionTests
    {
        [Test]
        public void ToInt32_NegativeValue_ReturnValue()
        {
            object intVal = -1;
            var parseValue = intVal.ToInt32(0);
            Assert.AreEqual(-1, parseValue);
        }

        [Test]
        public void ToInt32_PositiveValue_ReturnValue()
        {
            object intVal = 1;
            var parseValue = intVal.ToInt32(0);
            Assert.AreEqual(1, parseValue);
        }

        [Test]
        public void ToInt32_NullValue_NoExceptionAndReturnDefault()
        {
            object intVal = null;
            var parseValue = intVal.ToInt32(4);
            Assert.AreEqual(4, parseValue);
        }

        [Test]
        public void ToInt32_StringValue_NoExceptionAndReturnDefault()
        {
            object intVal = "string";
            var parseValue = intVal.ToInt32(4);
            Assert.AreEqual(4, parseValue);
        }

        [Test]
        public void ToInt32_EmptyValue_NoExceptionAndReturnDefault()
        {
            object intVal = String.Empty;
            var parseValue = intVal.ToInt32(4);
            Assert.AreEqual(4, parseValue);
        }

        // IsPositive
        [Test]
        public void IsPositive_NumberGreaterThenZero_ReturnTrue()
        {
            var i = 1;
            Assert.IsTrue(i.IsPositive());
        }
        [Test]
        public void IsPositive_NumberLessThenZero_ReturnFalse()
        {
            var i = -1;
            Assert.IsFalse(i.IsPositive());
        }
        [Test]
        public void IsPositive_NumberEqualsZero_ReturnFalse()
        {
            var i = 0;
            Assert.IsFalse(i.IsPositive());
        }

        // IsNegative
        [Test]
        public void IsNegative_NumberLessThenZero_ReturnTrue()
        {
            var i = -1;
            Assert.IsTrue(i.IsNegative());
        }
        [Test]
        public void IsNegative_NumberGreaterThenZero_ReturnTrue()
        {
            var i = 1;
            Assert.IsFalse(i.IsNegative());
        }
        [Test]
        public void IsNegative_NumberEqualsZero_ReturnFalse()
        {
            var i = 0;
            Assert.IsFalse(i.IsNegative());
        }

        //add
        [Test]
        public void Add_OneAddTwo_ReturnSum()
        {
            var result = 1.Add(2);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_OneAddZero_ReturnSum()
        {
            var result = 1.Add(0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_NullAddTwo_ReturnTwo()
        {
            object nullValue = null; 
            Assert.AreEqual(2, nullValue.Add(2));
        }

        //increment / decrement
        [Test]
        public void Increment_One_ReturnTwo()
        {
            object i = 1;
            Assert.AreEqual(2, i.Increment());
        }

        [Test]
        public void Increment_NullReturnOne()
        {
            object i = null;
            Assert.AreEqual(1, i.Increment());
        }

        [Test]
        public void Decrement_Two_ReturnOne()
        {
            object i = 2;
            Assert.AreEqual(1, i.Decrement());
        }

        [Test]
        public void Decrement_Null_ReturnMinusOne()
        {
            object i = null;
            Assert.AreEqual(-1, i.Decrement());
        }

        //round
        [Test]
        public void Round_Double_RoundUp()
        {
            Double d = 1.8;
            Assert.AreEqual(2, d.Round());
        }

        [Test]
        public void Round_Double_RoundDown()
        {
            Double d = 1.2;
            Assert.AreEqual(1, d.Round());
        }

        [Test]
        public void Round_Double_Middle()
        {
            Double d = 1.5;
            Assert.AreEqual(2, d.Round());
        }

        [Test]
        public void Round_Decimal_RoundUp()
        {
            var dec = new decimal(1.8);
            Assert.AreEqual(2, dec.Round());
        }

        [Test]
        public void Round_Decimal_RoundDown()
        {
            var dec = new decimal(1.2);
            Assert.AreEqual(1, dec.Round());
        }

        [Test]
        public void Round_Decimal_Middle()
        {
            var dec = new decimal(1.5);
            Assert.AreEqual(2, dec.Round());
        }

        [Test]
        public void Round_Float_RoundUp()
        {
            var f = 1.8f;
            Assert.AreEqual(2, f.Round());
        }

        [Test]
        public void Round_Float_RoundDown()
        {
            var f = 1.1f;
            Assert.AreEqual(1, f.Round());
        }

        [Test]
        public void Round_Float_Middle()
        {
            var f = 1.5f;
            Assert.AreEqual(2, f.Round());
        }

        [Test]
        public void Round_Null_ReturnZero()
        {
            1.CalculateWithMemory(x => x + 2);
            object n = null;
            Assert.AreEqual(0, n.Round());
        }

        //[Test]
        public void CalculateWithMemory()
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 100000; i < 100010; i++)
            {
                i.CalculateWithMemory(PrimeNumber.FindPrimeNumber);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            //****************
            var sw2 = new Stopwatch();
            sw2.Start();
            for (int i = 100000; i < 100010; i++)
            {
                i.CalculateWithMemory(PrimeNumber.FindPrimeNumber);
            }
            sw2.Stop();
            Console.WriteLine(sw2.ElapsedMilliseconds);
        }

        
    }
}
