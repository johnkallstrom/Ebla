global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using MediatR;
global using AutoMapper;
global using FluentValidation.AspNetCore;
global using FluentValidation;

global using Ebla.Application.Interfaces;
global using Ebla.Application.Common.Responses;
global using Ebla.Application.Common.Exceptions;
global using Ebla.Application.UseCases.Reservation.Commands;
global using Ebla.Application.UseCases.Loan.Commands;
global using Ebla.Application.UseCases.LibraryCard.Commands;

global using Ebla.Application.Books.Commands.CreateBook;
global using Ebla.Application.Books.Commands.UpdateBook;

global using Ebla.Domain.Entities;