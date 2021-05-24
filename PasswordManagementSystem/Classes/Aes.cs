using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagementSystem.Classes
{
    public static class Aes
    {
        /**
         * Provide string which will represent key,
         * check is it valid or not.
         * 
         */
        public static bool IsKeyValid(string key)
        {
            return key.Length == 16;
        }
        /**
         * Provide file path, to check
         * if file is already encrypted.
         * 
         */
        public static bool IsFileEncrypted(string filePath)
        {

            if (filePath.Length > 3)
            {
                return filePath.Substring(filePath.Length - 4) == ".aes";
            }
            return false;
        }
        /**
         * Aes encryption implementation,
         * provide file to encrypt path,
         * provide encrypted file path,
         * provide key,
         * to perform AES encryption operation.
         * 
         */
        public static bool EncryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                    fsIn.Close();
                                    cs.Close();
                                    fsCrypt.Close();
                                    aes.Clear();
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
        /**
         * Aes decryption implementation,
         * provide file to decrypt path,
         * provide decrypted file path,
         * provide key,
         * to perform AES decryption operation.
         * returns CryptographicException if decryption failed, if a key is not valid,
         * returns null if succeed
         */
        public static CryptographicException DecryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                    cs.Close();
                                    fsOut.Close();
                                    fsCrypt.Close();
                                    aes.Clear();
                                }
                            }
                        }
                    }
                }
            }
            catch (CryptographicException ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
