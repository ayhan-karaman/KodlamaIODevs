using System.Reflection;
using Application.Features.Users.Rules;
using Application.Features.Languages.Rules;
using Application.Features.Technologies.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.SocialMedias.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;

namespace Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
          services.AddAutoMapper(Assembly.GetExecutingAssembly());
          services.AddMediatR(Assembly.GetExecutingAssembly());
          

          services.AddScoped<LanguageBusinessRules>();
          services.AddScoped<TechnologyBusinessRules>();
          services.AddScoped<UserBusinessRules>();
          services.AddScoped<SocialMediaBusinessRules>();
          
          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
          

          
          
          
          

          return services;
    }
}