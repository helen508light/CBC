using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CBC.Utility
{
    class TripleDesEncrypter
    {
        // Стандартный размер блока (64 бита)
        public static readonly int BlockSize = 8;


        private static readonly TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();

        public static byte[] Encrypt(byte[] block, byte[] key)
        {
            // Здесь будет зашифрованный блок
            var encryptBlock = new byte[BlockSize];

            // Устанавливаем найстройки 3des provider'а
            TripleDes.Key = key;
            TripleDes.Padding = PaddingMode.None;
            TripleDes.IV = new byte[BlockSize];

            // Создаем и запускаем шифратор. 
            var encryptor = TripleDes.CreateEncryptor();
            encryptor.TransformBlock(block, 0, BlockSize, encryptBlock, 0);

            return encryptBlock;
        }
    }
}
