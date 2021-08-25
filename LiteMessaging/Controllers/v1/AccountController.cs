using Application.DTOs.Account;
using Application.DTOs.Messages;
using Application.Features.Commands.AccountCommand;
using Application.Features.Queries.AccountQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteMessaging.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// Create a new account for the give user
        /// </summary>
        /// <param name="user">User Account data</param>
        /// <returns>Ok</returns>
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] UserDTO user) 
            => Ok(await Mediator.Send(new CreateAccountCommand(user)));

        /// <summary>
        /// Get list of all user's messages.
        /// </summary>
        /// <param name="phone">The phone number.</param>
        /// <returns></returns>
        [HttpGet("get-user-message")]
        public async Task<IActionResult> GetUserMessages([FromQuery] string phone) =>
            Ok(await Mediator.Send(new GetMessagesQuery(phone)));

        /// <summary>
        /// Send message.
        /// </summary>
        /// <param name="param">Data</param>
        /// <returns></returns>
        [HttpPost("send-meesage")]
        public async Task<IActionResult> SendMessage([FromBody] MsgParam param) =>
            Ok(await Mediator.Send(new SendCommand(param)));

        /// <summary>
        /// Add a token to the given phone number.
        /// </summary>
        /// <param name="param">Update data.</param>
        /// <returns></returns>
        [HttpPut("refrech-token")]
        public async Task<IActionResult> UpdateToken([FromBody] TokenParam param) => 
            Ok(await Mediator.Send(new UpdateTokenCommand(param)));

        /// <summary>
        /// Search specifics users by thier names.
        /// </summary>
        /// <param name="name">name to request with</param>
        /// <returns></returns>
        [HttpGet("search-for-user")]
        public async Task<IActionResult> SearchFor([FromQuery] string name) =>
            Ok(await Mediator.Send(new SearchForCommand(name)));
    }
}
