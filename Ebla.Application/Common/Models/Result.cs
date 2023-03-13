namespace Ebla.Application.Common.Models
{
    public class Result<T> : IResult<T>
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public T Value { get; set; }

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