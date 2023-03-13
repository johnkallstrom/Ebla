namespace Ebla.Application.Common.Interfaces
{
    public interface IResult<T>
    {
        bool Succeeded { get; set; }
        string[] Errors { get; set; }
        T Value { get; set; }
        void Success();
        void Failure(string[] errors);
    }
}
