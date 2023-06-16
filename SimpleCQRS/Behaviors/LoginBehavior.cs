using MediatR;

namespace SimpleCQRS.Behaviors
{
    public class LoginBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoginBehavior<TRequest, TResponse>> logger;

        public LoginBehavior(ILogger<LoginBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response  = await next();
            logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
