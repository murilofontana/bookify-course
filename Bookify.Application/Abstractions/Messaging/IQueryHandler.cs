﻿using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TReponse> : IRequestHandler<TQuery, Result<TReponse>>
    where TQuery : IQuery<TReponse>
{
}
