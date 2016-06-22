using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;

namespace Common
{
    public static class LicenseHelper
    {
        // can be changed to anything
        private static byte[] _salt = Encoding.ASCII.GetBytes("rju-12@#o;354=");

        // can be changed to anything
        public const String USER_ID_ENCRYPTION_STRING = "1@!h#w0$";

        // can be changed to anything
        private const String LICENSE_KEY_PATH = "SMPRkey.lic";

        [DllImport("Kernel32.dll", SetLastError = true)]
        extern static bool GetVolumeInformation(string vol, StringBuilder name, int nameSize, out uint serialNum, out uint maxNameLen, out uint flags, StringBuilder fileSysName, int fileSysNameSize);
        private static uint GetVolumeSerial(string driveLetter)
        {
            uint serialNum, maxNameLen, flags;
            bool ok = GetVolumeInformation(driveLetter, null, 0, out serialNum, out maxNameLen, out flags, null, 0);
            return serialNum;
        }

        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// DecryptStringAES().  The sharedSecret parameters must match.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
        public static string EncryptStringAES(string plainText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// EncryptStringAES(), using an identical sharedSecret.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        public static String GetUserId()
        {
            var diskLetter = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            var serial = GetVolumeSerial(diskLetter).ToString();
            return EncryptStringAES(diskLetter + serial, USER_ID_ENCRYPTION_STRING);
        }

        public static bool IsLicensed()
        {
            if (IsolatedStorageHelper.Exists(LICENSE_KEY_PATH))
            {
                byte[] encryptedLicenseData = IsolatedStorageHelper.Load(LICENSE_KEY_PATH);
                String encryptedLicenseString = Encoding.UTF8.GetString(encryptedLicenseData);

                // right now it's not used, we don't check what's in
                // if the file exists and it decrypts without exceptions, we assume that it's ok
                // but this data can be used to store license date, user name, email and so on...
                String decryptedLicenseKey = DecryptStringAES(encryptedLicenseString, GetUserId());
                return StringComparer.Ordinal.Equals(decryptedLicenseKey, "01'\"@'. *!@^@*&#%89~{]{~");
            }

            return false;
        }

        public static void SaveLicenseKey(String licenseKey)
        {
            String decryptedLicenseKey = DecryptStringAES(licenseKey, GetUserId());
            byte[] decryptedLicenseData = Encoding.UTF8.GetBytes(decryptedLicenseKey);
            byte[] encryptedLicenseData = Encoding.UTF8.GetBytes(licenseKey);
            IsolatedStorageHelper.Save(LICENSE_KEY_PATH, encryptedLicenseData);
        }

        public static bool RemoveLicenseKey()
        {
            return IsolatedStorageHelper.Delete(LICENSE_KEY_PATH);
        }        
    }
}
