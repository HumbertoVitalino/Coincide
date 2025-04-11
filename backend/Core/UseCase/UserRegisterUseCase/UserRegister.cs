using Core.Commons;
using Core.Interfaces;
using Core.UseCase.UserRegisterUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.UserRegisterUseCase;

public class UserRegister(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<UserRegisterInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<Output> Handle(UserRegisterInput request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
