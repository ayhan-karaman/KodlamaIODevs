using System.Reflection;
using Application.Features.Users.Rules;
using Application.Features.Languages.Rules;
using Application.Features.Technologies.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.UserSocialMedias.Rules;
using Core.Application.Pipelines.Authorization;

namespace Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
          services.AddAutoMapper(Assembly.GetExecutingAssembly());
          services.AddMediatR(Assembly.GetExecutingAssembly());
          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

          
          services.AddScoped<LanguageBusinessRules>();
          services.AddScoped<TechnologyBusinessRules>();
          services.AddScoped<UserBusinessRules>();
          services.AddScoped<UserSocialMediaBusinessRules>();

          
          
          

          return services;
    }
}