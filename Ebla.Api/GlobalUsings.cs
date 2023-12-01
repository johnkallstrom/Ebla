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
global using Ebla.Application.Common.Responses;

global using Ebla.Application.UseCases.User.Commands;
global using Ebla.Application.UseCases.User.Queries;
global using Ebla.Application.UseCases.Review.Queries;
global using Ebla.Application.UseCases.Reservation.Commands;
global using Ebla.Application.UseCases.Reservation.Queries;
global using Ebla.Application.UseCases.Loan.Commands;
global using Ebla.Application.UseCases.Loan.Queries;
global using Ebla.Application.UseCases.LibraryCard.Commands;
global using Ebla.Application.UseCases.LibraryCard.Queries;
global using Ebla.Application.UseCases.Library.Queries;

global using Ebla.Application.Books.Queries.GetBooks;
global using Ebla.Application.Books.Queries.GetBookById;
global using Ebla.Application.Books.Commands.CreateBook;
global using Ebla.Application.Books.Commands.DeleteBook;
global using Ebla.Application.Books.Commands.UpdateBook;
global using Ebla.Application.Authors.Queries.GetAuthors;
global using Ebla.Application.Genres.Queries.GetGenres;
global using Ebla.Application.Authors.Queries.GetAuthorById;

global using Ebla.Infrastructure;
global using Ebla.Persistence;
global using Ebla.Persistence.Helpers;