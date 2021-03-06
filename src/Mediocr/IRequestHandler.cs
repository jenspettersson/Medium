namespace Mediocr
{
    public interface IRequestHandler<in TRequest, out TResponse> where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest request);
    }
}