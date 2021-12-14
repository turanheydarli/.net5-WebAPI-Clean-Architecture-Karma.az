using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public interface IPagingResult<T> : IResult
    {
        List<T> Data { get; }

        int TotalItemCount { get; }
    }
}