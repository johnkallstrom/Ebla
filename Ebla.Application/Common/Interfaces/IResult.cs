namespace Ebla.Application.Common.Interfaces
{
    public interface IResult
    {
        bool Succeeded { get; set; }
        string[] Errors { get; set; }
        void Success();
        void Failure(string[] errors);
    }
}
