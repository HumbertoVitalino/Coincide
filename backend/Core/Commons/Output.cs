using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Core.Commons;

public class Output
{
    private readonly List<string> _messages = [];

    private List<string> _errorMessages = [];

    public IReadOnlyCollection<string>? ErrorMessages => _errorMessages?.AsReadOnly();

    public bool IsValid { get; private set; }

    public IReadOnlyCollection<string>? Messages => _messages?.AsReadOnly();

    public object? Result { get; private set; }

    public Output(object result)
    {
        IsValid = true;
        _messages = new List<string>();
        _errorMessages = new List<string>();
        AddResult(result);
    }

    public Output(ValidationResult validationResult)
    {
        _errorMessages = new List<string>();
        _messages = new List<string>();
        ProcessValidationResults(validationResult);
    }

    public Output(IEnumerable<ValidationResult> validationResults)
    {
        _errorMessages = new List<string>();
        _messages = new List<string>();
        ProcessValidationResults(validationResults.ToArray());
    }

    private void CreateErrorMessagesWhenThereIsNone()
    {
        if (_errorMessages == null)
            _errorMessages = new List<string>();
    }

    private void ProcessValidationResults(params ValidationResult[] validationResults)
    {
        foreach (ValidationResult validationResult in validationResults)
            AddValidationResult(validationResult);

        VerifyValidty();
    }

    private void VerifyErrorMessages(ValidationResult validationResult)
    {
        CreateErrorMessagesWhenThereIsNone();
        _errorMessages.AddRange(validationResult.Errors.Select((ValidationFailure e) => e.ErrorMessage).ToList());
    }

    private void VerifyValidty()
    {
        IsValid = ErrorMessages?.Count == 0;
    }

    public void AddErrorMessage(string message)
    {
        AddErrorMessage(message);
        VerifyValidty();
    }

    public void AddErrorMessages(params string[] messages)
    {
        foreach (string text in messages)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("message is null");
            }

            _errorMessages.Add(text);
        }

        VerifyValidty();
    }

    public void AddMessage(string message)
    {
        AddMessages(message);
    }

    public void AddMessages(params string[] messages)
    {
        foreach (string text in messages)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("message is null");
            }

            _messages.Add(text);
        }
    }

    public void AddResult(object result)
    {
        Result = result ?? throw new NullReferenceException();
    }

    public void AddValidationResult(ValidationResult validationResult)
    {
        IsValid = validationResult.IsValid;
        VerifyErrorMessages(validationResult);
    }

    public T? GetResult<T>()
    {
        return (T?)Result;
    }

    public void SetToInvalid() => IsValid = false;
}
