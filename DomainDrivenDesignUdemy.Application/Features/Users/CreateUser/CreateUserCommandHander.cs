using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Users;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Users.CreateUser;

internal sealed class CreateUserCommandHander : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHander(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //iş kuralları
        await _userRepository.CreateAsync(
            request.Name, 
            request.Email, 
            request.Password, 
            request.Country, 
            request.City, 
            request.Street, 
            request.PostalCode, 
            request.FullAddress, 
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
