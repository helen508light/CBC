using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBC.Helper;
using CBC.Storage;

namespace CBC.Utility
{
    class MessageAuthenticationCodeGenerator
    {
        // Наше хранилище ключей
        private readonly KeyStorage _keyStorage;

        // В конструкторе передаем хранище ключей
        public MessageAuthenticationCodeGenerator(KeyStorage keyStorage)
        {
            _keyStorage = keyStorage;
        }

        // Основной метод. Создание имитовставки.
        public string GenerateMac(string text)
        {
            // Переводим сообщение в массив блоков (массивов) и создаем вектор инициализации
            var byteText = ByteConverter.ToByte(text);
            var initializatonVector = new byte[TripleDesEncrypter.BlockSize];

            // Вне цикла применяем XOR к первому блоку и вектору инициализации и шифруем его 
            var encryptedBlock = XoR(initializatonVector, byteText[0]);
            encryptedBlock = TripleDesEncrypter.Encrypt(encryptedBlock, _keyStorage.Key1);

            // В цикле для каждого блока применяем XOR с предыдущем и шифруем.
            for (int i = 1; i < byteText.Length; i++)
            {
                encryptedBlock = XoR(encryptedBlock, byteText[i]);
                encryptedBlock = TripleDesEncrypter.Encrypt(encryptedBlock, _keyStorage.Key1);
            }
            // На выходе делаем финальное шифрование.
            var byteMac = TripleDesEncrypter.Encrypt(encryptedBlock, _keyStorage.Key2);

            return BitConverter.ToString(byteMac);
        }

        // Функция сложения блоков по модулю 2
        private byte[] XoR(byte[] encryptedBlock, byte[] block)
        {
            var resultBlock = new byte[TripleDesEncrypter.BlockSize];

            for (int i = 0; i < encryptedBlock.Length; i++)
            {
                resultBlock[i] = (byte)(encryptedBlock[i] ^ block[i]);
            }

            return resultBlock;
        }
    }
}
