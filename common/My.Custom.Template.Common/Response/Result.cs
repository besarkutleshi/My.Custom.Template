﻿namespace My.Custom.Template.Common.Response;

public record Result
{
    public Result()
    {

    }
    private Result(bool isSuccess, Success success)
    {
        IsSuccess = isSuccess;
        Response = success;
    }

    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Success Response { get; } = null!;
    public Error Error { get; } = null!;

    public static Result Success(Success success) => new(true, success);
    public static Result Failure(Error error) => new(false, error);

    public bool IsSuccessfulWithResponse()
        => IsSuccess && Response is not null && Response.Result is not null;
}
