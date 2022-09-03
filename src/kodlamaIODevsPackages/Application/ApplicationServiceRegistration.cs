using System.Reflection;
using Application.Features.Languages.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
          services.AddAutoMapper(Assembly.GetExecutingAssembly());
          services.AddMediatR(Assembly.GetExecutingAssembly());

          services.AddScoped<LanguageBusinessRules>();

          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

          return services;
    }
}