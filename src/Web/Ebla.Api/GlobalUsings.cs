﻿global using Microsoft.OpenApi.Models;
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

global using Ebla.Application.UseCases.Authors.Queries;
global using Ebla.Application.UseCases.Authors.Responses;
global using Ebla.Application.UseCases.Books.Commands;
global using Ebla.Application.UseCases.Books.Queries;
global using Ebla.Application.UseCases.Books.Responses;
global using Ebla.Application.UseCases.Genres.Queries;
global using Ebla.Application.UseCases.Genres.Responses;
global using Ebla.Application.UseCases.Libraries.Queries;
global using Ebla.Application.UseCases.Libraries.Responses;
global using Ebla.Application.UseCases.Loans.Commands;
global using Ebla.Application.UseCases.Loans.Queries;
global using Ebla.Application.UseCases.Loans.Responses;
global using Ebla.Application.UseCases.Reservations.Commands;
global using Ebla.Application.UseCases.Reservations.Queries;
global using Ebla.Application.UseCases.Reservations.Responses;
global using Ebla.Application.UseCases.Reviews.Queries;
global using Ebla.Application.UseCases.Reviews.Responses;
global using Ebla.Application.UseCases.Users.Commands;
global using Ebla.Application.UseCases.Users.Queries;
global using Ebla.Application.UseCases.Users.Responses;
global using Ebla.Application.UseCases.Statistics.Queries;
global using Ebla.Application.UseCases.Statistics.Responses;

global using Ebla.Infrastructure;
global using Ebla.Persistence;
global using Ebla.Persistence.Helpers;