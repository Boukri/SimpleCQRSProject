using MediatR;
using SimpleCQRS.Notifications;
using SimpleCQRS.Services;

namespace SimpleCQRS.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddNotification>
    {
        private readonly ProductService productService;

        public EmailHandler(ProductService productService)
        {
            this.productService = productService;
        }

        public async Task Handle(ProductAddNotification notification, CancellationToken cancellationToken)
        {
            await productService.EventOcurred(notification.Product, "Email sent of adding a new product");
            await Task.CompletedTask;
        }
    }
}
