namespace Ebla.Application.UseCases.Statistics.Queries
{
    public class GetTotalAmountOfBooksQueryHandler : IRequestHandler<GetTotalAmountOfBooksQuery, int>
    {
        public Task<int> Handle(GetTotalAmountOfBooksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}