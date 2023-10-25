namespace Ebla.Web.Models
{
    public record LoginResponse
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }
    }
}
