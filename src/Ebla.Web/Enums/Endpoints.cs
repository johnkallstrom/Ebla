namespace Ebla.Web.Enums
{
    public static class Endpoints
    {
        // GET
        public const string Authors = "/api/authors";
        public const string Books = "/api/books";
        public const string Genres = "/api/genres";
        public const string Libraries = "/api/libraries";
        public const string Loans = "/api/loans";
        public const string Reservations = "/api/reservations";
        public const string Reviews = "/api/reviews";
        public const string Users = "/api/users";
        public const string Statistics = "/api/statistics";

        // POST
        public const string Login = "/api/users/login";
        public const string CreateBook = "/api/books/create";
    }
}