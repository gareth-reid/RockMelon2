using System;
using System.Linq;
using System.Reflection;
using Autofac;
using EntityFramework.Common.Repositories;
using Module = Autofac.Module;

namespace EntityFramework.Common.Modules
{
    public class DataModule : Module
    {
        public static void RegisterGenericRepositories(ContainerBuilder builder, System.Reflection.Assembly assemblyWhereGenericRepositoriesLive)
        {
            var genericRepositoryType = typeof(IGenericRepository<>);
            RegisterGenericType(builder, assemblyWhereGenericRepositoriesLive, genericRepositoryType);

            var genericAuditableRepositoryType = typeof(IGenericAuditableRepository<>);
            RegisterGenericType(builder, assemblyWhereGenericRepositoriesLive, genericAuditableRepositoryType);
        }

        protected override void Load(ContainerBuilder builder)
        {
            var genericRepositoryType = typeof(IGenericRepository<>);
            var repositoryMapperTypes = genericRepositoryType.Assembly.GetExportedTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract)
                .Where(t => IsAssignableToGenericType(t, genericRepositoryType))
                .ToArray();

            foreach (var type in repositoryMapperTypes)
            {
                if (type.IsGenericType)
                    builder.RegisterGeneric(type).AsImplementedInterfaces().InstancePerLifetimeScope();
                else
                    builder.RegisterType(type).AsImplementedInterfaces().InstancePerLifetimeScope();
            }
        }

        //http://stackoverflow.com/questions/74616/how-to-detect-if-type-is-another-generic-type
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            if (interfaceTypes.Where(it => it.IsGenericType).Any(it => it.GetGenericTypeDefinition() == genericType))
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return baseType.IsGenericType &&
                baseType.GetGenericTypeDefinition() == genericType ||
                IsAssignableToGenericType(baseType, genericType);
        }

        private static void RegisterGenericType(ContainerBuilder builder, Assembly assemblyWhereGenericRepositoriesLive,
                                        Type genericRepositoryType)
        {
            var repositoryMapperTypes = assemblyWhereGenericRepositoriesLive.GetExportedTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract)
                .Where(t => IsAssignableToGenericType(t, genericRepositoryType))
                .ToArray();

            foreach (var type in repositoryMapperTypes)
            {
                if (type.IsGenericType)
                    builder.RegisterGeneric(type).AsImplementedInterfaces().InstancePerLifetimeScope();
                else
                    builder.RegisterType(type).AsImplementedInterfaces().InstancePerLifetimeScope();
            }
        }
    }
}