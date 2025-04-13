using FluentValidation;

namespace Core.UseCase.UserRegisterUseCase.Boundaries;

public class UserRegisterValidator : AbstractValidator<UserRegisterInput>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Confirmation).NotEmpty();
    }
}
