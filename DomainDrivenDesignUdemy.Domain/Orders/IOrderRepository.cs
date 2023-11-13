namespace DomainDrivenDesignUdemy.Domain.Orders;
public interface IOrderRepository
{
    Task CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default);
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
}
