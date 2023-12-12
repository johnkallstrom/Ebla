namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public int Id { get; set; }
    }
}
