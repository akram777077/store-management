using Core.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Featurs.UnitType.Commands.Requests;
using Core.Featurs.UnitType.Commands.validator;


namespace Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //configuration of the mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //configuration of the automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var commandTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => 
                    !t.IsAbstract && 
                    typeof(UnitTypeNameOnlyCommand).IsAssignableFrom(t)
                );

            // Register NameOfUnitTypeValidator<T> for each concrete command
            foreach (var commandType in commandTypes)
            {
                var validatorType = typeof(NameOfUnitTypeValidator<>).MakeGenericType(commandType);
                var validatorInterface = typeof(IValidator<>).MakeGenericType(commandType);
                services.AddTransient(validatorInterface, validatorType);
            }
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;

        }
    }
}
