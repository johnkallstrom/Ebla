namespace Ebla.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<Book, BookSlimResponse>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<Author, AuthorSlimResponse>().ReverseMap();

            CreateMap<Genre, GenreResponse>().ReverseMap();
            CreateMap<Review, ReviewResponse>().ReverseMap();
            CreateMap<Reservation, ReservationResponse>().ReverseMap();
            CreateMap<Loan, LoanResponse>().ReverseMap();
            CreateMap<LibraryCard, LibraryCardResponse>().ReverseMap();
            CreateMap<Library, LibraryResponse>().ReverseMap();
            CreateMap<Library, LibrarySlimResponse>().ReverseMap();

            CreateMap<CreateLibraryCardCommand, LibraryCard>();
            CreateMap<UpdateLibraryCardCommand, LibraryCard>();

            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationCommand, Reservation>();

            CreateMap<CreateLoanCommand, Loan>();
            CreateMap<UpdateLoanCommand, Loan>();
        }
    }
}