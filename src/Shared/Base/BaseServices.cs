using Serilog;
using Shared.Models;

namespace Shared.Base;

public class BaseServices
{
    public Result<T> HandleError<T>(string errorCode, Exception ex)
    {
        var failure = Error.Failure(errorCode, ex.Message);
        Log.Error("Unexpected error occurred: {@Error}", failure);
        return Result<T>.Failure(failure);
    }

    public Result HandleError(string errorCode, Exception ex)
    {
        var failure = Error.Failure(errorCode, ex.Message);
        Log.Error("Unexpected error occurred: {@Error}", failure);
        return Result.Failure(failure);
    }
}