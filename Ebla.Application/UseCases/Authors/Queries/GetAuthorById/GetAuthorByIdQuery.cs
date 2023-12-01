namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorByIdQuery : IRequest<AuthorResponse>
    {
        public int Id { get; set; }
    }
}
