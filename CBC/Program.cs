using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBC.Entity;
using CBC.Storage;
using CBC.Utility;

namespace CBC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше сообщение");
            var messageText = Console.ReadLine();

            var macGenerator = new MessageAuthenticationCodeGenerator(new KeyStorage());
            var messageMac = macGenerator.GenerateMac(messageText);

            var message = new Message { Text = messageText, Mac = messageMac };
            Console.WriteLine("Имитовставка: " + message.Mac);

            var noiseCreator = new NoiseGenerator();

            Console.WriteLine(
                "Введите номер случая:\n" +
                "1.Сообщение доставлено без помех\n" +
                "2.Изменили текст сообщения\n" +
                "3.Изменили и хэш и текст сообщения"
                );
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    noiseCreator.ChangeMessageText(message);
                    break;
                case "3":
                    noiseCreator.ChangeMessageTextAndHash(message);
                    break;
            }

            Console.WriteLine("Получено новое сообщение: " + message.Text);
            Console.WriteLine("Имитовставка: " + message.Mac);

            var newMessageMac = macGenerator.GenerateMac(message.Text);
            Console.WriteLine("Имитовставка после валидации: " + newMessageMac);

            if (message.Mac.Equals(newMessageMac))
            {
                Console.WriteLine("Сообщение не было изменено");
            }
            else
            {
                Console.WriteLine("Сообщение было изменено");
            }

            Console.ReadKey();
        }
    }
}
