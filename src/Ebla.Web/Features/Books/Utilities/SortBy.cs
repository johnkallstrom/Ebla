namespace Ebla.Web.Features.Books.Utilities
{
    public static class SortBy
    {
        public static Func<BookViewModel, object> Id = (x) => x.Id;
        public static Func<BookViewModel, object> Title = (x) => x.Title;
        public static Func<BookViewModel, object> Author = (x) => x.Author;
        public static Func<BookViewModel, object> Genre = (x) => x.Genre;
        public static Func<BookViewModel, object> Language = (x) => x.Language;
        public static Func<BookViewModel, object> Published = (x) => x.Published;
        public static Func<BookViewModel, object> CreatedOn = (x) => x.CreatedOn;
    }
}
