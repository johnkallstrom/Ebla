namespace Ebla.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Library, opt => opt.MapFrom(src => src.Library.Name))
                .ReverseMap();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Loan, LoanDto>().ReverseMap();
            CreateMap<LibraryCard, LibraryCardDto>().ReverseMap();
            CreateMap<Library, LibraryDto>().ReverseMap();

            CreateMap<CreateLibraryCardCommand, LibraryCard>();
            CreateMap<UpdateLibraryCardCommand, LibraryCard>();

            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationCommand, Reservation>();

            CreateMap<CreateLoanCommand, Loan>();
            CreateMap<UpdateLoanCommand, Loan>();
        }
    }
}