using System.Reflection;
using Autofac;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Users;
using Module = Autofac.Module;

namespace Transporter.Infrastructure.IoC.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;

            //dla wszystkich implementacji IcommandHandler w assembly przydziela im komende
            
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();
                
            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
            
            
        }
    }
}