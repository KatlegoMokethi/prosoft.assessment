using System.Reflection;
using FeedbackSystem.Application.Commands.SubmitFeedback;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            //Rgister MediatR
            services.AddMediatR(typeof(SubmitFeedbackHandler).GetTypeInfo().Assembly);

            //RegisterAutoMapper
            services.AddAutoMapper(typeof(SubmitFeedbackHandler).GetTypeInfo().Assembly);

            //RegisterValidators
            services.AddTransient<IValidator<SubmitFeedbackCommand>, SubmitFeedbackValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}

