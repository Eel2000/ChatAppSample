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
    public class SearchForCommand : IRequest<Response<IReadOnlyList<UserDTO>>>
    {
        public string Name { get; set; }
        public SearchForCommand(string name)
        {
            this.Name = name;
        }
    }

    public class SearchForCommandHandler : IRequestHandler<SearchForCommand, Response<IReadOnlyList<UserDTO>>>
    {
        private readonly IUserService userService;
        public SearchForCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Response<IReadOnlyList<UserDTO>>> Handle(SearchForCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.GetUserByName(request.Name);
            return new Response<IReadOnlyList<UserDTO>>(result);
        }
    }
}
