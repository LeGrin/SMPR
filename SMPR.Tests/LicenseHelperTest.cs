using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SMPR.Tests
{    
    [TestClass()]
    public class LicenseHelperTest
    {
        [TestMethod()]
        public void EncryptStringAESTest1()
        {
            string plainText = "sa!!fsadfewrwe";
            string sharedSecret = LicenseHelper.USER_ID_ENCRYPTION_STRING;
            string expected = plainText;
            string actual = LicenseHelper.DecryptStringAES(LicenseHelper.EncryptStringAES(plainText, sharedSecret), sharedSecret);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void EncryptStringAESTest2()
        {
            string plainText = LicenseHelper.GetUserId();
            string sharedSecret = LicenseHelper.USER_ID_ENCRYPTION_STRING;
            string expected = plainText;
            string actual = LicenseHelper.DecryptStringAES(LicenseHelper.EncryptStringAES(plainText, sharedSecret), sharedSecret);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void EncryptStringAESTest3()
        {
            string plainText = "DHNHl3v820c028nFTvmdow==";
            string sharedSecret = LicenseHelper.USER_ID_ENCRYPTION_STRING;            
            string actual = LicenseHelper.DecryptStringAES(plainText, sharedSecret);                        
        }
    }
}
