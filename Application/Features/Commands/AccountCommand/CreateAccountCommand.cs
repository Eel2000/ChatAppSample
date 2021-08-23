using Application.DTOs.Account;
using Application.Interfaces;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.AccountCommand
{
    public class CreateAccountCommand : IRequest<Response<UserDTO>>
    {
        public UserDTO User { get; set; }

        public CreateAccountCommand(UserDTO user)
        {
            this.User = user;
        }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Response<UserDTO>>
    {
        private readonly IUserService userService;

        public CreateAccountCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Response<UserDTO>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.CreateAccount(request.User);
            if(result is null)
            {
                throw new InvalidOperationException("Processing error...");
            }

            return new Response<UserDTO>(result, "Account Created SuccessFuly");
        }
    }
}
