using MediatR;
using SimpleCQRS.Models;

namespace SimpleCQRS.Notifications
{
    public record ProductAddNotification(ProductModel Product):INotification;
}
