namespace Ebla.Application.Common.Models
{
    public class Result : IResult
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        public void Failure(string[] errors)
        {
            Succeeded = false;
            Errors = errors;
        }

        public void Success()
        {
            Succeeded = true;
            Errors = null;
        }
    }
}