using Application.DTOs.Account;
using Application.DTOs.Messages;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Create a new Account For This User.
        /// </summary>
        /// <param name="user">Data for account creation.</param>
        /// <returns><see cref="UserDTO"/> The Created user.</returns>
        Task<UserDTO> CreateAccount(UserDTO user);

        /// <summary>
        /// Return the given phone user.
        /// </summary>
        /// <param name="phone">Telephone number.</param>
        /// <returns><see cref="UserDTO"/>The Requested User.</returns>
        Task<UserDTO> GetUserByNumber(string phone);

        /// <summary>
        /// Add the firebase token to user for messaging push.
        /// </summary>
        /// <param name="phone">Telephone</param>
        /// <param name="token">The token</param>
        /// <returns><see cref="Task{bool}"/> <seealso cref="true"/> if it's updated otherwise <see cref="false"/></returns>
        Task<bool> UpdateTokenAsync(string phone, string token);

        /// <summary>
        /// Get All user messages.
        /// </summary>
        /// <param name="phone">The user phone number.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> The list of messages.</returns>
        Task<IReadOnlyList<MessageDTO>> GetMessages(string phone);

        /// <summary>
        /// Send message.
        /// </summary>
        /// <param name="msg">Message data.</param>
        /// <returns><see cref="MessageDTO"/> The result.</returns>
        Task<MessageDTO> SendAsync(MsgParam msg);
    }
}
