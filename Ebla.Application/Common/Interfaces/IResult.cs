namespace Ebla.Application.Common.Interfaces
{
    public interface IResult
    {
        bool Succeeded { get; init; }
        string[] Errors { get; init; }
    }

    public interface IResult<T>
    {
        bool Succeeded { get; init; }
        string[] Errors { get; init; }
        T Data { get; init; }
    }
}
