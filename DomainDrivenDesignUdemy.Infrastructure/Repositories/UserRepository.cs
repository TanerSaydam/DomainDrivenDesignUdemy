using DomainDrivenDesignUdemy.Domain.Users;
using DomainDrivenDesignUdemy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignUdemy.Infrastructure.Repositories;
internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, email, password, country, city, street, postalCode, fullAddress);
        await _context.Users.AddAsync(user, cancellationToken);

        return user;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _context.Users.ToListAsync(cancellationToken);
    }
}
