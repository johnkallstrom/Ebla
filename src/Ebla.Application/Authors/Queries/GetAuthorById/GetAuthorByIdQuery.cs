namespace Ebla.Application.Authors.Queries
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public int Id { get; set; }
    }
}
