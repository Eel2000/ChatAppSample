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

namespace Application.Features.Queries.AccountQueries
{
    public class GetMessagesQuery : IRequest<Response<IReadOnlyList<MessageDTO>>>
    {
        public string Phone { get; set; }
        public GetMessagesQuery(string phone)
        {
            this.Phone = phone;
        }
    }

    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, Response<IReadOnlyList<MessageDTO>>>
    {
        private readonly IUserService userService;
        public GetMessagesQueryHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Response<IReadOnlyList<MessageDTO>>>Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.GetMessages(request.Phone);
            return new Response<IReadOnlyList<MessageDTO>>(result);
        }
    }
}
