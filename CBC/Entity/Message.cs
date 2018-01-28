using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBC.Entity
{
    class Message
    {
        public string Text { get; set; }

        public string Mac { get; set; }

        public Message()
        {

        }

        public Message(string text, string mac)
        {
            Text = text;

            Mac = mac;
        }
    }
}
