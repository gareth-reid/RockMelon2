using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RockMelon.Tools.Extension
{
    public static class StringExtension
    {
        public static string ToMyString(this object sValue)
        {
            try
            {
                if (!String.IsNullOrEmpty(sValue.ToString()))
                {
                    return sValue.ToString();
                }
                return String.Empty;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static int WordCount(this object sValue)
        {
            try
            {
                var stringValue = sValue.ToString();
                if(!String.IsNullOrEmpty(stringValue))
                {
                    stringValue = stringValue.Trim();
                    var splitIntoWords = stringValue.Split(' ');
                    if (splitIntoWords.ContainsElements() && String.IsNullOrEmpty(splitIntoWords[0]))
                    {
                        //was an empty string
                        return 0;
                    }
                    return splitIntoWords.Count();
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Same as split but handles the null check
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string[] TheSplit(this object str, char splitChar)
        {
            try
            {
                return str.ToString().Split(splitChar);
            }
            catch
            {
                return new string[0];
            }
        }

        public static bool IsValidEmailAddress(this object s)
        {
            try
            {
                return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(s.ToString());
            }
            catch
            {
                return false;
            }
            
        }

        public static string RemoveWhiteSpace(this object s)
        {
            try
            {
                var returnValue = s.ToString().Replace(" ", "");
                returnValue = returnValue.Trim();
                return returnValue;
            }
            catch
            {
                return "";
            }
        }

        //IsNumber
        public static bool IsNumber(this object num)
        {
            try
            {
                int iValue = 0;
                if(int.TryParse(num.ToString(), out iValue))
                {
                    return true;
                }
                double dValue = 0;
                if (double.TryParse(num.ToString(), out dValue))
                {
                    return true;
                }
                float fValue = 0;
                if (float.TryParse(num.ToString(), out fValue))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// hasg to MD5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static MD5CryptoServiceProvider s_md5 = null;
        public static string ToMD5(this string s)
        {
            if (s_md5 == null) //creating only when needed
                s_md5 = new MD5CryptoServiceProvider();
            Byte[] newdata = Encoding.Default.GetBytes(s);
            Byte[] encrypted = s_md5.ComputeHash(newdata);
            return BitConverter.ToString(encrypted).Replace("-", "").ToLower();
        }
        
        /// <summary>
        /// Replace all line endings with html break
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string NlToBreak(this string s)
        {
            try
            {
                return s.Replace("\r\n", "<br />").Replace("\n", "<br />");
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Encrypt(this string message, string passphrase)
        {
            byte[] Results;
            var UTF8 = new System.Text.UTF8Encoding();

            var HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));

            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToEncrypt = UTF8.GetBytes(message);

            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return Convert.ToBase64String(Results);
        }

        public static string Decrypt(this string message, string passphrase)
        {
            if (message == string.Empty)
                return string.Empty;

            byte[] Results;
            var UTF8 = new System.Text.UTF8Encoding();

            var HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));

            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToDecrypt = Convert.FromBase64String(message);

            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch
            {
                Results = new byte[0];
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return UTF8.GetString(Results);
        }
    }
}
