using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CBC.Storage
{
    // Класс для хранения ключей. Генерировать ключи будем в конструкторе
    class KeyStorage
    {
        private byte[] _key1 = new byte[24];
        public byte[] Key1
        {
            get { return _key1; }
            set { _key1 = value; }
        }

        private byte[] _key2 = new byte[24];
        public byte[] Key2
        {
            get { return _key2; }
            set { _key2 = value; }
        }

        public KeyStorage()
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(Key1);
            randomNumberGenerator.GetBytes(Key2);
        }
    }
}
