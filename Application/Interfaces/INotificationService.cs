using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Send firebase push notification to the user.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone"></param>
        /// <param name="body"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<string> SendAsync(string token, string phone, string body, string username = "");
    }
}
