// -----------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="IndicInfo India Pvt Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RetailPOS.CommonLayer.Unity
{
    #region Using directives

    using System;
    using System.Linq;
    using Microsoft.Practices.Unity;

    #endregion

    /// <summary>
    /// This class has used for Inversion Of Controls. This class creates the container for the 
    /// Application Objects and provide other method definitions to resolve and register the objects
    /// </summary>
    public static class RetailPOSUnityContainer
    {
        /// <summary>
        /// private member instance for unity Container
        /// </summary>
        private static IUnityContainer container;

        /// <summary>
        /// Property to hold the Unity Container
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
            set
            {
                container = value;
            }
        }

        /// <summary>
        /// Defination for the Unity Resolve Property.
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <returns>
        /// Object
        /// </returns>
        public static T Resolve<T>()
        {
            if (container.IsRegistered(typeof(T)))
            {
                return container.Resolve<T>();
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Defination for the Unity Resolve Property with name property.
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="name">string specifies the name</param>
        /// <returns>
        /// Object
        /// </returns>
        public static T Resolve<T>(string name)
        {
            if (container.IsRegistered(typeof(T), name))
            {
                return container.Resolve<T>(name, new ResolverOverride[] { });
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Defination for the Unity Register.
        /// </summary>
        /// <param name="from">Type</param>
        /// <param name="to">Type</param>
        public static void Register(Type from, Type to)
        {
            if (container.Registrations.Any(c => c.MappedToType == to && c.RegisteredType == from) == false)
            {
                container.RegisterType(from, to, new ContainerControlledLifetimeManager() { }, new InjectionMember[] { });
            }
        }

        /// <summary>
        /// This generic method has been used to register the objects
        /// </summary>
        /// <typeparam name="T">object map from</typeparam>
        /// <typeparam name="U">object map to</typeparam>
        public static void Register<T, U>()
        {
            container.RegisterType(typeof(T), typeof(U));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="propertyName"></param>
        public static void Register<T, U>(string propertyName)
        {
            container.RegisterType(typeof(T), typeof(U), new InjectionProperty(propertyName));
        }

        /// <summary>
        /// To register the instance.
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="name">string specifies the name</param>
        /// <param name="objectToRegister">Object</param>
        public static void RegisterInstance<T>(string name, T objectToRegister)
        {
            container.RegisterInstance<T>(name, objectToRegister);
        }
    }
}