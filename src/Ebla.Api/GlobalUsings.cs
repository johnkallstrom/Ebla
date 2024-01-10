global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using System.Reflection;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc.Filters;
global using System.Text;
global using AutoMapper;

global using Ebla.Api;
global using Ebla.Api.Authorization;
global using Ebla.Api.Middleware;

global using Ebla.Application;
global using Ebla.Application.Common;
global using Ebla.Application.Interfaces.Identity;
global using Ebla.Application.Interfaces.Jwt;

global using Ebla.Application.Authors.Queries;
global using Ebla.Application.Authors.Responses;
global using Ebla.Application.Books.Commands;
global using Ebla.Application.Books.Queries;
global using Ebla.Application.Books.Responses;
global using Ebla.Application.Genres.Queries;
global using Ebla.Application.Genres.Responses;
global using Ebla.Application.Libraries.Queries;
global using Ebla.Application.Libraries.Responses;
global using Ebla.Application.Loans.Commands;
global using Ebla.Application.Loans.Queries;
global using Ebla.Application.Loans.Responses;
global using Ebla.Application.Reservations.Commands;
global using Ebla.Application.Reservations.Queries;
global using Ebla.Application.Reservations.Responses;
global using Ebla.Application.Reviews.Queries;
global using Ebla.Application.Reviews.Responses;
global using Ebla.Application.Users.Commands;
global using Ebla.Application.Users.Queries;
global using Ebla.Application.Users.Responses;
global using Ebla.Application.Statistics.Queries;

global using Ebla.Infrastructure;
global using Ebla.Persistence;
global using Ebla.Persistence.Helpers;