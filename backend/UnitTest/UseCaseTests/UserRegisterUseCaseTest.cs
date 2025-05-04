using Core.Domain;
using Core.Interfaces;
using Core.UseCase.UserRegisterUseCase.Boundaries;
using Core.UseCase.UserRegisterUseCase;
using Moq;
using AutoBogus;

namespace UnitTest.UseCaseTests;

public class UserRegisterUseCaseTest
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UserRegister _useCase;

    public UserRegisterUseCaseTest()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _useCase = new UserRegister(_userRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact(DisplayName = "Handle > Success > User registered successfully")]
    public async Task Handle_ShouldRegisterUserSuccessfully()
    {
        // Arrange
        var input = new AutoFaker<UserRegisterInput>()
            .RuleFor(x => x.Password, "password123")
            .RuleFor(x => x.Confirmation, "password123")
            .Generate();

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(input.Email)).ReturnsAsync((User?)null);

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.ErrorMessages);
        Assert.NotNull(result.Result);
        _userRepositoryMock.Verify(repo => repo.Create(It.IsAny<User>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "Handle > Fail > User with email already exists")]
    public async Task Handle_ShouldReturnError_WhenUserAlreadyExists()
    {
        // Arrange
        var input = new AutoFaker<UserRegisterInput>().Generate();

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(input.Email))
            .ReturnsAsync(new AutoFaker<User>().Generate());

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains("User already exists!", result.ErrorMessages);
        Assert.Null(result.Result);
        _userRepositoryMock.Verify(repo => repo.Create(It.IsAny<User>()), Times.Never);
        _unitOfWorkMock.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact(DisplayName = "Handle > Fail > Passwords do not match")]
    public async Task Handle_ShouldReturnError_WhenPasswordsDoNotMatch()
    {
        // Arrange
        var input = new AutoFaker<UserRegisterInput>()
            .RuleFor(x => x.Password, "password123")
            .RuleFor(x => x.Confirmation, "differentPassword")
            .Generate();

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(input.Email)).ReturnsAsync((User?)null);

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains("Passwords are different!", result.ErrorMessages);
        _userRepositoryMock.Verify(repo => repo.Create(It.IsAny<User>()), Times.Never);
        _unitOfWorkMock.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}

