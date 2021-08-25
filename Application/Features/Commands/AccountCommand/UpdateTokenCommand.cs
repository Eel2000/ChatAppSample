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
    public class UpdateTokenCommand : IRequest<Response<bool>>
    {
        public TokenParam TokenParam { get; set; }
        public UpdateTokenCommand(TokenParam tokenParam)
        {
            this.TokenParam = tokenParam;
        }
    }

    public class UpdateTokenCommandHandler : IRequestHandler<UpdateTokenCommand, Response<bool>>
    {
        private readonly IUserService userService;

        public UpdateTokenCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Response<bool>> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.UpdateTokenAsync(request.TokenParam.Phone, request.TokenParam.Token);
            return new Response<bool>(result, "Account updated");
        }
    }
}
