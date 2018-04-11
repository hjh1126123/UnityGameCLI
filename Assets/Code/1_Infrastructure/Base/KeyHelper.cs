using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJH.KEY;

namespace Assets.Code._1_Infrastructure.Base
{
    public class KeyHelper
    {
        private const string keyCode = "1998";
        private const string IVCode = "0327";
        private KeyInstance Key;

        private static KeyHelper _instance;
        public static KeyHelper GetInstance()
        {
            if (_instance == null)
                _instance = new KeyHelper();

            return _instance;
        }
        private KeyHelper() { Key = new KeyInstance(keyCode,IVCode); }

        public string EncryptData(string DecryptData)
        {
            return Key.DataEncrypt(DecryptData);
        }

        public string DecryptData(string EncryptData)
        {
            return Key.DataDecrypt(EncryptData);
        }
    }
}
