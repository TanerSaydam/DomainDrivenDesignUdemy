namespace DomainDrivenDesignUdemy.Domain.Orders;
public sealed class Order
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public OrderStatusEnum Status { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}
