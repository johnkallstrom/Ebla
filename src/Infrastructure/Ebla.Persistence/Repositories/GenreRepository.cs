namespace Ebla.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly EblaDbContext _context;

        public GenreRepository(EblaDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, double> GetStatisticsData()
        {
            IEnumerable<IGrouping<string, Genre>> groups = _context.Genres.GroupBy(genre => genre.Name).AsEnumerable();

            var flattened = groups
                .SelectMany(group => group.Select(genre => new 
                { 
                    Genre = group.Key, 
                    Books = genre.Books == null ? 0 : genre.Books.Count() 
                })).OrderByDescending(x => x.Books).ToList();

            return new Dictionary<string, double>();
        }
    }
}