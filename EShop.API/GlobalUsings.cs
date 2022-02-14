global using Microsoft.AspNetCore.Mvc;
global using MediatR;

global using EShop.Domain.Core.Abstractions;
global using EShop.Application.Commands.SellerCommands;
global using EShop.Application.Commands.CategoryCommands;


global using EShop.API.Extensions;
global using EShop.Application;
global using EShop.Domain.AggregatesModel.CategoryAggregateModel;
global using EShop.Domain.AggregatesModel.SellerAggregateModel;
global using EShop.Infrastructure;
global using EShop.Infrastructure.Repositories;
global using EShop.Domain.AggregatesModel.ProductAggregateModel;


using Microsoft.EntityFrameworkCore;