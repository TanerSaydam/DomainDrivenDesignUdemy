namespace DomainDrivenDesignUdemy.Domain.Orders;

public enum OrderStatusEnum
{
    AwaitingApproval = 1,
    BeingPrepared = 2,
    InTransit = 3,
    Delivered = 4
}