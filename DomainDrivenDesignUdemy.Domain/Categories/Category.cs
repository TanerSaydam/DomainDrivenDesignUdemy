using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Products;
using DomainDrivenDesignUdemy.Domain.Shared;

namespace DomainDrivenDesignUdemy.Domain.Categories;
public sealed class Category : Entity
{
    public Category(Guid id, Name name): base(id)
    {
        Name = name;
    }

    public Name Name { get; private set; }
    public ICollection<Product> Products { get; private set; }

    public void ChangeName(string name)
    {
        Name = new(name);
    }
}
