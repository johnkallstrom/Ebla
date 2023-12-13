namespace Ebla.Application.UseCases.Statistics.Responses
{
    public record StatisticsDto(int totalBooks, Dictionary<string, double> genreData);
}