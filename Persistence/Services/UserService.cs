using Application.DTOs.Account;
using Application.DTOs.Messages;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly LiteMessagingContext liteMessagingContext;

        public UserService(LiteMessagingContext liteMessagingContext)
        {
            this.liteMessagingContext = liteMessagingContext;
        }

        public async Task<UserDTO> CreateAccount(UserDTO user)
        {
            var alreadyCreated = await liteMessagingContext.Users.FirstOrDefaultAsync(x => x.Phone == user.PhoneNumber);
            if(alreadyCreated is not null)
            {
                throw new AccessViolationException("This number is already related to an account");
            }

            //TODO: Add the phone nnumber checking with phonNumber Utils package.

            var u = new User
            {
                ID = Guid.NewGuid().ToString(),
                Phone = user.PhoneNumber,
                Username = user.Username
            };

            await this.liteMessagingContext.Users.AddAsync(u);
            await liteMessagingContext.SaveChangesAsync();
            return user;
        }

        public async Task<IReadOnlyList<MessageDTO>> GetMessages(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("The required field PHONE is missing.");
            }

            var messages = await liteMessagingContext.Messages.Where(x => x.Phone == phone)
                .OrderByDescending(x=>x.Date)
                .ToListAsync();

            var msg = new List<MessageDTO>();
            foreach (var item in messages)
            {
                msg.Add(new MessageDTO
                {
                    Body = item.Body,
                    Date = item.Date,
                    ReceiverPhone = item.ReceiverPhone,
                    ReceiverName = (await liteMessagingContext.Users
                    .FirstOrDefaultAsync(x=>x.Phone ==  item.ReceiverPhone)).Username,
                    ID = item.ID
                });
            }

            return msg;
        }

        public async Task<UserDTO> GetUserByNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("The required field PHONE is missing.");
            }

            var u = await liteMessagingContext.Users.FirstOrDefaultAsync(x => x.Phone == phone);
            if(u is null)
            {
                throw new KeyNotFoundException("this number does not have an account");
            }

            return new UserDTO
            {
                Username = u.Username,
                PhoneNumber = u.Phone,
            };
        }

        public async Task<MessageDTO> SendAsync(MsgParam msg)
        {
            //TODO: Launch PushNotification here
            var message = new Message
            {
                ID = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Body = msg.Body,
                Phone = msg.Phone,
                ReceiverPhone = msg.ReceiverPhone
            };

            await liteMessagingContext.Messages.AddAsync(message);
            await liteMessagingContext.SaveChangesAsync();

            return new MessageDTO
            {
                ID = message.ID,
                Date = message.Date,
                Body = message.Body,
                Phone = message.Phone,
                ReceiverPhone = message.ReceiverPhone,
                ReceiverName = (await liteMessagingContext.Users
                .FirstOrDefaultAsync(x => x.Phone == message.ReceiverPhone)).Phone,
            };
        }

        public async Task<bool> UpdateTokenAsync(string phone, string token)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("The required field PHONE is missing.");
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("Cannot continue because there is not any token.");
            }

            var user = await liteMessagingContext.Users.FirstOrDefaultAsync(x => x.Phone == phone);
            if (user is null)
            {
                throw new KeyNotFoundException("this number does not have an account");
            }
            user.Token = token;

            liteMessagingContext.Users.Update(user);
            await liteMessagingContext.SaveChangesAsync();

            return true;
        }
    }
}
