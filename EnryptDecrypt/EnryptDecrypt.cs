﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EnryptDecrypt
{
    public class EnryptDecrypt
    {
        public static string EncryptString(string text, string salt)
        {
            try
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = Encoding.UTF8.GetBytes(salt);
                key = mD5CryptoServiceProvider.ComputeHash(key);
                using (Aes aes = Aes.Create())
                {
                    using (ICryptoTransform iCryptoTransform = aes.CreateEncryptor(key, aes.IV))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Write))
                            {
                                using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                                {
                                    streamWriter.Write(text);
                                }
                                byte[] iv = aes.IV;
                                byte[] decryptedContent = memoryStream.ToArray();
                                byte[] result = new byte[iv.Length + decryptedContent.Length];
                                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                                Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
                                return Convert.ToBase64String(result);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string DecryptString(string text, string salt)
        {
            try
            {
                byte[] fromBase64String = Convert.FromBase64String(text);
                byte[] iv = new byte[16];
                byte[] cipher = new byte[fromBase64String.Length - iv.Length];
                Buffer.BlockCopy(fromBase64String, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fromBase64String, iv.Length, cipher, 0, cipher.Length);
                byte[] key = Encoding.UTF8.GetBytes(salt);
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key = mD5CryptoServiceProvider.ComputeHash(key);
                using (Aes aes = Aes.Create())
                {
                    using (ICryptoTransform iCryptoTransform = aes.CreateDecryptor(key, iv))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipher))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Read))
                            {
                                using (StreamReader streamReader = new StreamReader(cryptoStream))
                                {
                                    return streamReader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
