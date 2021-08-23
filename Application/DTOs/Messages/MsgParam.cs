using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Messages
{
    public class MsgParam
    {

        /// <summary>
        /// The message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The receiver phone number.
        /// </summary>
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// the user phone
        /// </summary>
        public string Phone { get; set; }
    }
}
