using MediatR;

namespace eShopping.SharedKernel.MediatR
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}