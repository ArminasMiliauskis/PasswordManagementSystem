using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Classes
{
    class Des
    {

        public string EncryptData(string strData, string strKey, bool mode)
        {
            byte[] key = { }; //Encryption Key   64bits
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray;

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                if (mode == false) { ObjDES.Mode = CipherMode.ECB; };
                if (mode == true) { ObjDES.Mode = CipherMode.CBC; };
                inputByteArray = Encoding.UTF8.GetBytes(strData);
                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                return Convert.ToBase64String(Objmst.ToArray());//encrypted string  
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string DecryptData(string strData, string strKey, bool mode)
        {
            byte[] key = { };// Key   
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[strData.Length];

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                if (mode == false) { ObjDES.Mode = CipherMode.ECB; };
                if (mode == true) { ObjDES.Mode = CipherMode.CBC; };
                inputByteArray = Convert.FromBase64String(strData);

                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(Objmst.ToArray());
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
