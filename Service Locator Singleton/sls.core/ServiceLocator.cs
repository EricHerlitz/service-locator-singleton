using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace sls.core
{
    public class ServiceLocator
    {
        #region Singleton

        private static readonly ServiceLocator instance = new ServiceLocator();
        private UnityContainer Ioc = new UnityContainer();

        static ServiceLocator() { }

        private ServiceLocator()
        {
            // What do we want? Bootstraping!
            // When do we want it? NOW!
            Bootstrap();
        }

        public static ServiceLocator Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        /// <summary>
        /// Bootstraps all registered 
        /// </summary>
        private void Bootstrap()
        {
            // Get all injected instances (objects)
            IEnumerable<Type> injectedInstances =
                    from a in AppDomain.CurrentDomain.GetAssemblies()
                    from t in a.GetTypes()
                    where t.IsDefined(typeof(InjectAttribute), false)
                    select t;

            // the class type: instanceType
            foreach (Type instanceType in injectedInstances)
            {
                // get the injected attributes
                var injectAttributes = instanceType.GetCustomAttributes(
                        attributeType: typeof(InjectAttribute),
                        inherit: false)
                    .Cast<InjectAttribute>();

                // the interface: injectAttribute.RegisteredType
                foreach (InjectAttribute injectAttribute in injectAttributes)
                {
                    if (injectAttribute.LifetimeManager != null)
                    {
                        Ioc.RegisterType(
                            @from: injectAttribute.RegisteredType,
                            to: instanceType,
                            lifetimeManager: injectAttribute.LifetimeManager);
                    }
                    else
                    {
                        Ioc.RegisterType(
                            @from: injectAttribute.RegisteredType,
                            to: instanceType);
                    }
                }
            }
        }
        
        public T Resolve<T>()
        {
            return Ioc.Resolve<T>();
        }
    }

    public sealed class InjectAttribute : Attribute
    {
        public Type RegisteredType;
        public LifetimeManager LifetimeManager;

        public InjectAttribute() { }

        public InjectAttribute(Type type)
        {
            RegisteredType = type;
        }

        public InjectAttribute(Type type, bool singleton)
        {
            RegisteredType = type;
            LifetimeManager = singleton ? new ContainerControlledLifetimeManager() : null;
        }
    }
}
