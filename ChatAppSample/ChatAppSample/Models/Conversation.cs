using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppSample.Models
{
    public class Conversation
    {
        public string ContactName { get; set; }
        public string LastRead { get; set; }
        public DateTime Time { get; set; }
        public string Phone { get; set; }
        public string Initials { get; set; }

        public override string ToString()
        {

            if (!ReferenceEquals(ContactName, null))
            {
                if (ContactName.Contains(" "))
                {
                    var names = ContactName.Split(' ');
                    Initials = names[0].Substring(0, 1) + names[0].Substring(0, 1);
                }

                Initials = ContactName.Substring(0, 1);
            }
            return Initials;
        }
    }
}
