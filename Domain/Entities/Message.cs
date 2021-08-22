﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string SenderPhone { get; set; }
        public string SenderID { get; set; }
        public string UserID { get; set; }

        public virtual User User { get; set; }

    }
}