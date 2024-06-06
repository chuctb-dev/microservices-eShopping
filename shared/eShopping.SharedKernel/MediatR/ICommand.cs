using MediatR;

namespace eShopping.SharedKernel.MediatR
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}