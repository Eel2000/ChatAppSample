using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Messages
{
    public class MessageDTO
    {
        /// <summary>
        /// The Message unique identifier.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Sent date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The receiver phone number.
        /// </summary>
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// The name of the receiver.
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// the user phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// the push notification result.
        /// </summary>
        public string DeliveryRepport { get; set; }
    }
}
