namespace Ebla.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly EblaDbContext _context;

        public GenreRepository(EblaDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, double> GetGenreStatisticsData()
        {
            // Group each genre by name
            IEnumerable<IGrouping<string, Genre>> groups = _context.Genres.GroupBy(genre => genre.Name).AsEnumerable();

            // Create anonymous list containing genre name and book amount
            var flattened = groups
                .SelectMany(group => group.Where(genre => genre.Books != null).Select(genre => new 
                { 
                    Genre = group.Key, 
                    Books = genre.Books.Count() 
                })).OrderByDescending(x => x.Books).ToList();

            // Calculate percentage from the amount of books each genre has and the total books stored in db
            int total = _context.Books.Count();
            var data = new Dictionary<string, double>();
            foreach (var item in flattened)
            {
                double percentage = Math.Round((double)item.Books / total * 100, 2);
                data.Add(item.Genre, percentage);
            }

            return data;
        }
    }
}