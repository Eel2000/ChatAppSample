using Application.DTOs.Messages;
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
    public class SendCommand : IRequest<Response<MessageDTO>>
    {
       public MsgParam Param { get; set; }

        public SendCommand(MsgParam param)
        {
            this.Param = param;
        }
    }

    public class SendCommandHandler : IRequestHandler<SendCommand, Response<MessageDTO>>
    {
        private readonly IUserService userService;
        public SendCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Response<MessageDTO>> Handle(SendCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.SendAsync(request.Param);
            if(result is null)
            {
                throw new InvalidOperationException("An error occured when requesting");
            }

            return new Response<MessageDTO>(result);
        }
    }
}
