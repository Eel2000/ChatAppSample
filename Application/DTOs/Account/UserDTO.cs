using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Account
{
    public class UserDTO
    {
        /// <summary>
        /// The user's account phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Username for this account.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The firebase token.
        /// </summary>
        public string Token { get; set; }
    }
}
