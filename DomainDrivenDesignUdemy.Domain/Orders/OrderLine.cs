using DomainDrivenDesignUdemy.Domain.Products;

namespace DomainDrivenDesignUdemy.Domain.Orders;

public sealed class OrderLine
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; } 
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }    
}