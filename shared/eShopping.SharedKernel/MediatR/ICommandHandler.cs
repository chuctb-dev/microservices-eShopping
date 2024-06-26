﻿using MediatR;

namespace eShopping.SharedKernel.MediatR
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
         where TCommand : ICommand<TResponse>
    {
    }
}