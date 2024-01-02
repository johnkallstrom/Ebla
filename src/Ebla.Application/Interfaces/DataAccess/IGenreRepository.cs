namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IGenreRepository
    {
        Dictionary<string, double> GetGenreStatisticsData();
    }
}
