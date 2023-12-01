global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using MediatR;
global using AutoMapper;
global using FluentValidation.AspNetCore;
global using FluentValidation;

global using Ebla.Application.UseCases.Reservation.Commands;
global using Ebla.Application.Common.Responses;
global using Ebla.Application.Books.Commands.CreateBook;
global using Ebla.Application.Books.Commands.UpdateBook;
global using Ebla.Application.LibraryCards.Commands.CreateLibraryCard;
global using Ebla.Application.LibraryCards.Commands.UpdateLibraryCard;
global using Ebla.Application.Loans.Commands.CreateLoan;
global using Ebla.Application.Common.Exceptions;
global using Ebla.Application.Loans.Commands.UpdateLoan;
global using Ebla.Application.Interfaces;

global using Ebla.Domain.Entities;