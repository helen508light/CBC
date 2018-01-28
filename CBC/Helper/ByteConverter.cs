using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBC.Helper
{
    class ByteConverter
    {
        // Стандартный размер блока, 64 бита
        private static readonly int blockSize = 8;

        public static byte[][] ToByte(string text)
        {
            // Если количество блоков не целое число, то добавляем строке пробелов
            if (text.Length % blockSize != 0)
            {
                text = AddSpaces(text);
            }

            // Создаем двумерный массив (Массив блоков)
            int blockCount = text.Length / blockSize;
            var blocks = new byte[blockCount][];

            for (int i = 0; i < blockCount; i++)
            {
                blocks[i] = Encoding.Unicode.GetBytes(text.Substring(i * blockSize, blockSize));
            }

            return blocks;
        }

        // Функция добавления пробелов в конец 
        private static string AddSpaces(string text)
        {
            while (text.Length % blockSize != 0)
            {
                text = text.Insert(text.Length, " ");
            }

            return text;
        }
    }
}
