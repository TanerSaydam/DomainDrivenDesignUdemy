using DomainDrivenDesignUdemy.Domain.Products;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Products.GetAllProduct;
public sealed record GetAllProductQuery():IRequest<List<Product>>;
