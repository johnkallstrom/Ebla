﻿global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using System.Reflection;
global using MediatR;
global using Ebla.Api;
global using Ebla.Application;
global using Ebla.Application.Common.Models;
global using Ebla.Application.Books.Queries.GetBooks;
global using Ebla.Infrastructure;
global using Ebla.Infrastructure.Persistence;
global using Ebla.Application.Books.Queries.GetBookById;
global using Ebla.Application.Users.Queries.GetUsers;
global using Ebla.Application.Users.Commands.CreateUser;
global using Ebla.Application.Books.Commands.CreateBook;
global using Ebla.Application.Books.Commands.DeleteBook;
global using Ebla.Application.Books.Commands.UpdateBook;
global using Ebla.Application.Users.Queries.GetUserById;
global using Ebla.Application.LibraryCards.Commands.CreateLibraryCard;
global using Ebla.Application.LibraryCards.Commands.UpdateLibraryCard;
global using Ebla.Application.Reservations.Commands.CreateReservation;
global using Ebla.Application.Reservations.Queries.GetReservationsByUserId;
global using Ebla.Application.Loans.Queries.GetLoansByUserId;
global using Ebla.Application.LibraryCards.Commands.DeleteLibraryCard;
global using Ebla.Application.LibraryCards.Queries.GetLibraryCardByUserId;
global using Ebla.Application.Authors.Queries.GetAuthors;
global using Ebla.Application.Genres.Queries.GetGenres;