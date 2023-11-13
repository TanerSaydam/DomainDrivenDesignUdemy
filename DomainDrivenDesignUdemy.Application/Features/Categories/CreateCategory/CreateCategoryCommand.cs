using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    string Name): IRequest;
