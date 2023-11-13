using DomainDrivenDesignUdemy.Domain.Categories;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Categories.GetAllCategory;
public sealed record GetAllCategoryQuery(): IRequest<List<Category>>;

internal sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllAsync(cancellationToken);
    }
}
