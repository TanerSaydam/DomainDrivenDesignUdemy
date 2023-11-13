using BenchmarkDotNet.Running;
using MediatR;

namespace DomainDrivenDesignUdemy.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Order order = new();
        //order.CreateOrder(1, "Domates");
        //order.CreateOrder(2, "Elma");
        //order.CreateOrder(3, "Armut");


        //DomainEventDispacther.Dispatch(order.DomainEvents);
        ////BenchmarkRunner.Run<BenchMarkService>();
        Console.ReadLine();
    }
}

public class Order
{
    private readonly IMediator _mediator;

    public Order(IMediator mediator)
    {
        _mediator = mediator;
    }

    public int Id { get; set; }
    public string ProductName { get; set; }
    public List<IDomainEvent> DomainEvents { get; } = new();
    public void CreateOrder(int id,  string productName)
    {
        Id = id;
        ProductName = productName;
        //kayıt işlemi
        _mediator.Publish(new OrderCompletedEvent(id));
        //DomainEvents.Add(new OrderCreatedEvent(id));
    }
}

public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        //İşlemlerimizi yapabiliriz
        return Task.CompletedTask;
    }
}

public class SendMailHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        //Mail gönderme işlemi
        return Task.CompletedTask;
    }
}

public class SendSmsHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        //Mail gönderme işlemi
        return Task.CompletedTask;
    }
}

public class OrderCompletedEvent : INotification
{
    public int Id { get; }
    public OrderCompletedEvent(int id)
    {
        Id = id;
    }
}

public static class DomainEventDispacther
{
    public static void Dispatch(List<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
        {
            if(domainEvent is OrderCreatedEvent orderEvent)
            {
                Console.WriteLine($"Order Event işleme başladı, Id: {orderEvent.OrderId}");
            }
        }
    }
}

public interface IDomainEvent
{

}

public class OrderCreatedEvent: IDomainEvent
{
    public int OrderId { get; }
    public OrderCreatedEvent(int orderId)
    {
       OrderId = orderId;
    }
}

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }
    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is not Entity entity)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }
}


public class A : Entity
{
    public A(Guid id) : base(id)
    {
    }
}