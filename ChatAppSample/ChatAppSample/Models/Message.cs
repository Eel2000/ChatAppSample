using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppSample.Models
{
    class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Sent { get; set; }
        public bool State { get; set; }
    }
}
