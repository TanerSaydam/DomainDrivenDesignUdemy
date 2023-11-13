using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Categories;
using DomainDrivenDesignUdemy.Domain.Orders;
using DomainDrivenDesignUdemy.Domain.Products;
using DomainDrivenDesignUdemy.Domain.Shared;
using DomainDrivenDesignUdemy.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructure.Context;
internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=DDDUdemyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<User>()
           .Property(p => p.Email)
           .HasConversion(email => email.Value, value => new(value));

        modelBuilder.Entity<User>()
           .Property(p => p.Password)
           .HasConversion(password => password.Value, value => new(value));

        modelBuilder.Entity<User>()
            .OwnsOne(p => p.Address);

        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder
                .Property(p => p.Amount)
                .HasColumnType("money");
            });

        modelBuilder.Entity<OrderLine>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder
                .Property(p => p.Amount)
                .HasColumnType("money");
            });
    }
}
