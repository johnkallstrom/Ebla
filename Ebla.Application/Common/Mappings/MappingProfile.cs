namespace Ebla.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));

            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));


            CreateMap<CreateLibraryCardCommand, LibraryCard>();
            CreateMap<UpdateLibraryCardCommand, LibraryCard>();

            CreateMap<CreateReservationCommand, Reservation>();
        }
    }
}