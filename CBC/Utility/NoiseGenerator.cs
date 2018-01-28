using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBC.Entity;

namespace CBC.Utility
{
    class NoiseGenerator
    {
        private static readonly string NewMessageText = "123456";

        private static readonly string NewMessageHash = "hjfdshijfahgiuewr";

        public Message ChangeMessageText(Message message)
        {
            message.Text = NewMessageText;

            return message;
        }

        public Message ChangeMessageTextAndHash(Message message)
        {
            message.Text = NewMessageText;
            message.Mac = NewMessageHash;

            return message;
        }
    }
}
