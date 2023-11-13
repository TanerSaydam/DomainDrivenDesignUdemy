using DomainDrivenDesignUdemy.Domain.Users;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Users.GetAllUser;
public sealed record GetAllUserQuery(): IRequest<List<User>>;
