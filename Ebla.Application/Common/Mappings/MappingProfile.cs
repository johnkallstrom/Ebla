﻿namespace Ebla.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorSlimDto>().ReverseMap();

            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Review, ReviewResponse>().ReverseMap();
            CreateMap<Reservation, ReservationResponse>().ReverseMap();
            CreateMap<Loan, LoanResponse>().ReverseMap();
            CreateMap<LibraryCard, LibraryCardDto>().ReverseMap();
            CreateMap<Library, LibraryDto>().ReverseMap();
            CreateMap<Library, LibrarySlimDto>().ReverseMap();

            CreateMap<CreateLibraryCardCommand, LibraryCard>();
            CreateMap<UpdateLibraryCardCommand, LibraryCard>();

            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationCommand, Reservation>();

            CreateMap<CreateLoanCommand, Loan>();
            CreateMap<UpdateLoanCommand, Loan>();
        }
    }
}