using NUnit.Framework;
using RockMelon.Tools.Extension;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RockMelon.Tools.Test.Extension
{
    [TestFixture]
    public class BoolExtensionTests
    {
        [Test]
        public void ToBool_True_ReturnTrue()
        {
            var bValue = true;
            Assert.IsTrue(bValue.ToBool());
        }

        [Test]
        public void ToBool_False_ReturnFalse()
        {
            var bValue = false;
            Assert.IsFalse(bValue.ToBool());
        }

        [Test]
        public void ToBool_Null_ReturnFalse()
        {
            object bValue = null;
            Assert.IsFalse(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringLowerCaseTrue_ReturnTrue()
        {
            object bValue = "true";
            Assert.IsTrue(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringCamelCaseTrue_ReturnTrue()
        {
            object bValue = "True";
            Assert.IsTrue(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringLowerCaseFalse_ReturnFalse()
        {
            object bValue = "false";
            Assert.IsFalse(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringCamelCaseFalse_ReturnFalse()
        {
            object bValue = "False";
            Assert.IsFalse(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringNotTrueOrFalse_ReturnFalse()
        {
            object bValue = "sgeer";
            Assert.IsFalse(bValue.ToBool());
        }

        //1/0
        [Test]
        public void ToBool_String1_ReturnTrue()
        {
            object bValue = "1";
            Assert.IsTrue(bValue.ToBool());
        }

        [Test]
        public void ToBool_String0_ReturnFalse()
        {
            object bValue = "0";
            Assert.IsFalse(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringX_ReturnFalse()
        {
            object bValue = "X";
            Assert.IsFalse(bValue.ToBool());
        }

        //Y/N
        [Test]
        public void ToBool_StringY_ReturnTrue()
        {
            object bValue = "Y";
            Assert.IsTrue(bValue.ToBool());
        }

        [Test]
        public void ToBool_StringN_ReturnFalse()
        {
            object bValue = "N";
            Assert.IsFalse(bValue.ToBool());
        }

        //*****ToYesNo
        [Test]
        public void ToYesNo_True_ReturnY()
        {
            object sValue = true;
            Assert.AreEqual("Y", sValue.ToYesNo());
        }

        [Test]
        public void ToYesNo_False_ReturnN()
        {
            object sValue = false;
            Assert.AreEqual("N", sValue.ToYesNo());
        }

        [Test]
        public void ToYesNo_Null_ReturnN()
        {
            object sValue = null;
            Assert.AreEqual("N", sValue.ToYesNo());
        }
    }
}
