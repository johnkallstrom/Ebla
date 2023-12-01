global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using System.Reflection;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc.Filters;
global using System.Text;

global using Ebla.Api;
global using Ebla.Api.Authorization;
global using Ebla.Api.Middleware;

global using Ebla.Application;
global using Ebla.Application.UseCases.User.Commands;
global using Ebla.Application.UseCases.User.Queries;
global using Ebla.Application.UseCases.Review.Queries;
global using Ebla.Application.UseCases.Reservation.Commands;
global using Ebla.Application.UseCases.Reservation.Queries;

global using Ebla.Application.Books.Queries.GetBooks;
global using Ebla.Application.Books.Queries.GetBookById;
global using Ebla.Application.Books.Commands.CreateBook;
global using Ebla.Application.Books.Commands.DeleteBook;
global using Ebla.Application.Books.Commands.UpdateBook;
global using Ebla.Application.LibraryCards.Commands.CreateLibraryCard;
global using Ebla.Application.LibraryCards.Commands.UpdateLibraryCard;
global using Ebla.Application.Loans.Queries.GetLoansByUserId;
global using Ebla.Application.LibraryCards.Commands.DeleteLibraryCard;
global using Ebla.Application.LibraryCards.Queries.GetLibraryCardByUserId;
global using Ebla.Application.Authors.Queries.GetAuthors;
global using Ebla.Application.Genres.Queries.GetGenres;
global using Ebla.Application.Loans.Commands.CreateLoan;
global using Ebla.Application.Loans.Commands.DeleteLoan;
global using Ebla.Application.Loans.Commands.UpdateLoan;
global using Ebla.Application.Authors.Queries.GetAuthorById;
global using Ebla.Application.Libraries.Queries.GetLibraries;
global using Ebla.Application.Libraries.Queries.GetLibraryById;
global using Ebla.Application.Loans.Queries.GetLoans;
global using Ebla.Application.Common.Responses;

global using Ebla.Infrastructure;
global using Ebla.Persistence;
global using Ebla.Persistence.Helpers;