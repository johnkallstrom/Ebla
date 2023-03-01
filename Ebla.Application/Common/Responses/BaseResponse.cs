namespace Ebla.Application.Common.Responses
{
    public abstract class BaseResponse
    {
        public bool Succeeded { get; set; } = false;
        public List<string> Errors { get; set; }
    }
}
