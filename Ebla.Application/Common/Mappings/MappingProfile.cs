namespace Ebla.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorSlimDto>().ReverseMap();

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<Book, BookSlimDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

            CreateMap<Genre, GenreDto>().ReverseMap();

            CreateMap<Library, LibraryDto>().ReverseMap();
            CreateMap<Library, LibrarySlimDto>().ReverseMap();

            CreateMap<LibraryCard, LibraryCardDto>().ReverseMap();
            CreateMap<CreateLibraryCardCommand, LibraryCard>();
            CreateMap<UpdateLibraryCardCommand, LibraryCard>();

            CreateMap<Loan, LoanDto>().ReverseMap();
            CreateMap<CreateLoanCommand, Loan>();
            CreateMap<UpdateLoanCommand, Loan>();

            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationCommand, Reservation>();

            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}