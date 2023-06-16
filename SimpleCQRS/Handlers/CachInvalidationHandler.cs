using MediatR;
using SimpleCQRS.Notifications;
using SimpleCQRS.Services;

namespace SimpleCQRS.Handlers
{
    public class CachInvalidationHandler : INotificationHandler<ProductAddNotification>
    {
        private readonly ProductService productService;

        public CachInvalidationHandler(ProductService productService)
        {
            this.productService = productService;
        }

        public async Task Handle(ProductAddNotification notification, CancellationToken cancellationToken)
        {
            await productService.EventOcurred(notification.Product, "Cache invalidated");
            await Task.CompletedTask;
        }
    }
}
