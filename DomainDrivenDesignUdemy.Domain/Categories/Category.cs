using DomainDrivenDesignUdemy.Domain.Products;

namespace DomainDrivenDesignUdemy.Domain.Categories;
public sealed class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
