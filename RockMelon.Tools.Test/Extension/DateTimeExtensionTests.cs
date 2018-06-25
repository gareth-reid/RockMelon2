using System;
using NUnit.Framework;
using RockMelon.Tools.Extension;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RockMelon.Tools.Test.Extension
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        private static DateTime _now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        [Test]
        public void SubtractDays_TodayMinusOne_ReturnYesterday()
        {
            DateTime? now = _now;
            now = now.SubtractDays(1);
            Assert.AreEqual(_now.AddDays(-1), now);
        }

        private DateTime? d;
        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void SubtractDays_NullMinusOneTrue_ThrowException()
        {
            d = null;
            d.SubtractDays(1, true);
        }

        [Test]
        public void SubtractDays_NullMinusOneTrue_NoExceptionReturnYesterday()
        {
            d = null;
            var now = d.SubtractDays(1);
            Assert.AreEqual(_now.AddDays(-1), now);
        }

        //first day of month
        [Test]
        public void GetFirstDateOfMonth_PassJan5_ReturnJan1()
        {
            d = new DateTime(2013, 1, 5);
            var firstDayOfMonth = d.GetFirstDateOfMonth();
            Assert.AreEqual(new DateTime(2013, 1, 1), firstDayOfMonth);
        }

        [Test]
        public void GetFirstDateOfMonth_PassNull_ReturnFirstDayOfThisMonth()
        {
            d = null;
            var firstDayOfMonth = d.GetFirstDateOfMonth();
            Assert.AreEqual(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), firstDayOfMonth);
        }

        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void GetFirstDateOfMonth_PassNull_ThrowException()
        {
            d = null;
            var firstDayOfMonth = d.GetFirstDateOfMonth(true);
            Assert.AreEqual(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), firstDayOfMonth);
        }

        //last day of month
        [Test]
        public void GetLastDateOfMonth_PassJan5_ReturnJan31()
        {
            d = new DateTime(2013, 1, 5);
            var lastDayOfMonth = d.GetLastDateOfMonth();
            Assert.AreEqual(new DateTime(2013, 1, 31), lastDayOfMonth);
        }

        [Test]
        public void GetLastDateOfMonth_PassNull_ReturnLastDayOfThisMonth()
        {
            d = null;
            var lastDayOfMonth = d.GetLastDateOfMonth();
            Assert.AreEqual(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 31), lastDayOfMonth);
        }

        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void GetLastDateOfMonth_PassNull_ThrowException()
        {
            d = null;
            d.GetLastDateOfMonth(true);
        }

        //WeekOfYear
        [Test]
        public void WeekOfYear_7April2013_Return14()
        {
            d = new DateTime(2013, 4, 7);
            Assert.AreEqual(14, d.WeekOfYear());
        }

        [Test]
        public void WeekOfYear_1Jan2013_Return1()
        {
            d = new DateTime(2013, 1, 1);
            Assert.AreEqual(1, d.WeekOfYear());
        }

        [Test]
        public void WeekOfYear_8Jan2013_Return2()
        {
            d = new DateTime(2013, 1, 8);
            Assert.AreEqual(2, d.WeekOfYear());
        }

        [Test]
        public void WeekOfYear_31Dec2013_Return52()
        {
            d = new DateTime(2013, 12, 31);
            Assert.AreEqual(52, d.WeekOfYear());
        }
    }
}
