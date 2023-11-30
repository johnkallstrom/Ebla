namespace Ebla.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorResponse>
    {
        public int Id { get; set; }
    }
}
