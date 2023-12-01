global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using MediatR;
global using AutoMapper;
global using FluentValidation.AspNetCore;
global using FluentValidation;

global using Ebla.Application.Interfaces;
global using Ebla.Application.Common.Responses;
global using Ebla.Application.Common.Exceptions;

global using Ebla.Application.UseCases.Authors.Responses;
global using Ebla.Application.UseCases.Books.Commands;
global using Ebla.Application.UseCases.Books.Responses;
global using Ebla.Application.UseCases.Genres.Responses;
global using Ebla.Application.UseCases.Libraries.Responses;
global using Ebla.Application.UseCases.LibraryCards.Commands;
global using Ebla.Application.UseCases.LibraryCards.Responses;
global using Ebla.Application.UseCases.Loans.Commands;
global using Ebla.Application.UseCases.Loans.Responses;
global using Ebla.Application.UseCases.Reservations.Commands;
global using Ebla.Application.UseCases.Reservations.Responses;
global using Ebla.Application.UseCases.Reviews.Responses;

global using Ebla.Domain.Entities;