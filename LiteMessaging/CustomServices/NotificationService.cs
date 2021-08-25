using Application.Interfaces;
using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteMessaging.CustomServices
{
    public class NotificationService : INotificationService
    {
        public async Task<string> SendAsync(string token, string phone, string body, string username = "")
        {
            try
            {
                var notification = new Message()
                {
                    Data = new Dictionary<string, string>()
                {
                    {"title", username },
                    {"body", body },
                    {"p", phone },
                },
                    Token = token
                };

                var response = await FirebaseMessaging.DefaultInstance.SendAsync(notification);

                return response;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, "FCM sending proccess");
                return "Not sent";
            }
        }
    }
}
