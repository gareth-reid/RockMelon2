using System;
using EntityFramework.Common.Context;
using EntityFramework.Common.Repositories;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using RockMelon.Repository.Context;

namespace Rockmelon.Factory
{
    public class Factory : IIocContainer
    {
        public readonly IKernel Kernel;
        public Factory(params INinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);           
        }
             
        public Factory()
        {
            Kernel = new StandardKernel();
            Kernel.Bind(x => x
                .FromAssembliesMatching("*")
                .SelectAllClasses()
                .BindDefaultInterface());
            Kernel.Bind<IBaseDbContext>().To<RockMelonContext>().WhenInjectedInto(typeof(IGenericAuditableRepository<>));
            Kernel.Bind<IUnitOfWork>().To<RockMelonContext>();
            // Kernel.Bind(typeof(IGenericAuditableRepository<>)).To(typeof(GenericAuditableRepository<>)).InSingletonScope();
        }

        /// <summary>
        /// Replace interface mapping -clear all and then add
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        public void Register<T>(object type)
        {
            Kernel.Rebind<T>().To(type.GetType());
        }

        /// <summary>
        /// Add to the implentations of a particular interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        public void RegisterExtra<T>(object type)
        {
            Kernel.Bind<T>().To(type.GetType());
        }

        public object Get(Type type)
        {
            try
            {
                return Kernel.Get(type);
            }
            catch (ActivationException exception)
            {
                throw exception;
            }
        }

        public T TryGet<T>()
        {
            return Kernel.TryGet<T>();
        }

        public T Get<T>()
        {
            try
            {
                return Kernel.Get<T>();
            }
            catch (ActivationException exception)
            {
                throw exception;
            }
        }

        public T Get<T>(string name, string value)
        {
            var result = Kernel.TryGet<T>(metadata => metadata.Has(name) &&
                         (string.Equals(metadata.Get<string>(name), value,
                                        StringComparison.InvariantCultureIgnoreCase)));

            if (Equals(result, default(T))) throw new ActivationException(null);
            return result;
        }

        public void Inject(object item)
        {
            Kernel.Inject(item);
        }

    }

}
