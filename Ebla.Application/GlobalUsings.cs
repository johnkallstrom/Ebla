﻿global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using Ebla.Application.Common.Models;
global using MediatR;
global using Ebla.Application.Common.Interfaces;
global using Ebla.Domain.Entities;
global using AutoMapper;
global using FluentValidation.AspNetCore;
global using FluentValidation;
global using Ebla.Application.Books.Commands.CreateBook;
global using Ebla.Application.Books.Commands.UpdateBook;
global using Ebla.Application.LibraryCards.Commands.CreateLibraryCard;
global using Ebla.Application.LibraryCards.Commands.UpdateLibraryCard;
global using Ebla.Application.Reservations.Commands.CreateReservation;
global using Ebla.Application.Loans.Commands.CreateLoan;
global using Ebla.Application.Common.Exceptions;
global using Ebla.Application.Reservations.Commands.UpdateReservation;
global using Ebla.Application.Loans.Commands.UpdateLoan;
global using Ebla.Application.Authors.Queries.GetAuthors;