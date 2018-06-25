using System.Collections.Generic;
using NUnit.Framework;
using RockMelon.Tools.Extension;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RockMelon.Tools.Test.Extension
{
    [TestFixture]
    public class CollectionExtension_ContainsElementsTests
    {
        [Test]
        public void ContainsElements_Int_OneElement_ReturnTrue()
        {
            var list = new List<int>() {1};
            Assert.IsTrue(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_Int_TwoElements_ReturnTrue()
        {
            var list = new List<int>() { 2,3 };
            Assert.IsTrue(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_String_OneElement_ReturnTrue()
        {
            var list = new List<string>() { "Test" };
            Assert.IsTrue(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_String_TwoElement_ReturnTrue()
        {
            var list = new List<string>() { "Test", "TestTwo" };
            Assert.IsTrue(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_String_ZeroElements_ReturnTrue()
        {
            var list = new List<string>() ;
            Assert.IsFalse(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_String_Null_ReturnTrue()
        {
            List<string> list = null;
            Assert.IsFalse(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_Int_ZeroElements_ReturnTrue()
        {
            var list = new List<int>();
            Assert.IsFalse(list.ContainsElements());
        }

        [Test]
        public void ContainsElements_Int_Null_ReturnTrue()
        {
            List<string> list = null;
            Assert.IsFalse(list.ContainsElements());
        }
    }
}
