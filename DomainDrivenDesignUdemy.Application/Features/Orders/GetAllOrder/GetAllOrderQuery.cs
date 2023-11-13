using DomainDrivenDesignUdemy.Domain.Orders;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Orders.GetAllOrder;
public sealed record GetAllOrderQuery():IRequest<List<Order>>;
