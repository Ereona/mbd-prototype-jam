using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace MurderByDeath.Utilities
{
    public enum FileName
    {
        
    }

    public static class StorageSystem
    {
        public static void SaveData<T>(T _data, FileName _fileName)
        {
            Aes iAes = Aes.Create();

            string _path = Application.persistentDataPath + "/" + GetFileName(_fileName);

            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream _dataStream = new FileStream(_path, FileMode.Create);

            byte[] _inputIV = iAes.IV;

            _dataStream.Write(_inputIV, 0, _inputIV.Length);

            CryptoStream _cryptStream = new CryptoStream(
                _dataStream,
                iAes.CreateEncryptor(GetSaveKey(), iAes.IV),
                CryptoStreamMode.Write
            );

            _formatter.Serialize(_cryptStream, _data);
            _cryptStream.Close();
            _dataStream.Close();
        }

        public static string LoadString(FileName _fileName)
        {
            string _data;
            
            string _path = Application.persistentDataPath + "/" + GetFileName(_fileName);

            if(File.Exists(_path))
            {
                FileStream _dataStream = new FileStream(_path, FileMode.Open);
                BinaryFormatter _formatter = new BinaryFormatter();
                CryptoStream _cryptoStream = DecryptStream(_dataStream);

                _data = _formatter.Deserialize(_cryptoStream) as string;
                _cryptoStream.Close();
                _dataStream.Close();

                return _data;
            }
            else
                Debug.LogError("Save file not found in " + _path);

            return _data = null;
        }

        public static string[] LoadStrings(FileName _fileName)
        {
            string[] _data;
            
            string _path = Application.persistentDataPath + "/" + GetFileName(_fileName);

            if(File.Exists(_path))
            {
                FileStream _dataStream = new FileStream(_path, FileMode.Open);
                BinaryFormatter _formatter = new BinaryFormatter();
                CryptoStream _cryptoStream = DecryptStream(_dataStream);

                _data = _formatter.Deserialize(_cryptoStream) as string[];
                _cryptoStream.Close();
                _dataStream.Close();

                return _data;
            }
            else
                Debug.LogError("Save file not found in " + _path);

            return _data = null;
        }

        private static CryptoStream DecryptStream(FileStream _dataStream)
        {
            Aes _oAes = Aes.Create();

            byte[] _outputIV = new byte[_oAes.IV.Length];

            _dataStream.Read(_outputIV, 0, _outputIV.Length);

            return new CryptoStream(
                _dataStream,
                _oAes.CreateDecryptor(GetSaveKey(), _outputIV),
                CryptoStreamMode.Read
            );
        }

        public static string SerializeToJson<T>(T _data)
        {
            return JsonUtility.ToJson(_data);
        }

        public static void DeleteData(FileName _fileName)
        {
            string _path = Application.persistentDataPath + "/" + GetFileName(_fileName);
            
            File.Delete(_path);
        }

        public static string GetFileName(FileName _fileName)
        {
            //switch(_fileName)
            //{
            //}
            return null;
        }

        private static byte[] GetSaveKey()
        {
            return new byte[] { 0x16, 0x15, 0x16, 0x15, 0x16, 0x15, 0x16, 0x15, 0x16, 0x15, 0x16, 0x15, 0x16, 0x15, 0x16, 0x15 };
        }
    }
}

