using MediatR;

namespace DomainDrivenDesignUdemy.Domain.Orders.Events;
public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //Mail gönderme işlemi
        return Task.CompletedTask;
    }
}



