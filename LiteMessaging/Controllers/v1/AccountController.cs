using Application.DTOs.Account;
using Application.Features.Commands.AccountCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteMessaging.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// Create a new account for the give user
        /// </summary>
        /// <param name="user">User Account data</param>
        /// <returns>Ok</returns>
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] UserDTO user) => Ok(await Mediator.Send(new CreateAccountCommand(user)));
    }
}
