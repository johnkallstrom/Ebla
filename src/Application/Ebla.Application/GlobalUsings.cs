global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using MediatR;
global using AutoMapper;
global using FluentValidation.AspNetCore;
global using FluentValidation;

global using Ebla.Application.Interfaces.Identity;
global using Ebla.Application.Interfaces.Jwt;
global using Ebla.Application.Interfaces.DataAccess;
global using Ebla.Application.Common;
global using Ebla.Application.Common.Exceptions;

global using Ebla.Application.Authors.Responses;
global using Ebla.Application.Books.Commands;
global using Ebla.Application.Books.Responses;
global using Ebla.Application.Genres.Responses;
global using Ebla.Application.Libraries.Responses;
global using Ebla.Application.Loans.Commands;
global using Ebla.Application.Loans.Responses;
global using Ebla.Application.Reservations.Commands;
global using Ebla.Application.Reservations.Responses;
global using Ebla.Application.Reviews.Responses;
global using Ebla.Application.Users.Responses;
global using Ebla.Application.Statistics.Responses;

global using Ebla.Domain.Entities;