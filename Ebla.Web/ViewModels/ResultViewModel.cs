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
        [JsonPropertyName("Token")]
        public T Data { get; set; }
    }
}