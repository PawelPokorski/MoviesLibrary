namespace MoviesLibrary.Application;

public record Result
{
    public bool IsSuccess { get; init; }
    public string[] Errors { get; init; } = [];
    public object? ReturnValue { get; set; }

    public static Result Success(object? value = null) => new() { IsSuccess = true, ReturnValue = value };
    public static Result Failure(params string[] errors) => new() { IsSuccess = false, Errors = errors };
}