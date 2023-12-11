namespace Ebla.Application.UseCases.Statistics.Queries
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, StatisticsDto>
    {
        public async Task<StatisticsDto> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}