namespace Ebla.Web.ViewModels
{
    public class ResultViewModel
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
    }

    public class ResultViewModel<T>
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        // Need this attribute to parse token from /api/login/users endpoint
        [JsonPropertyName("Token")]
        public T Data { get; set; }
    }
}