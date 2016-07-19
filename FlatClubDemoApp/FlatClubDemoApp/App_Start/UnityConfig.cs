using DataAccess.Users;
using DemoApp.Core;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using DataAccess.Groups;
using DataAccess.Stories;
using DemoApp.Core.Groups;
using DemoApp.Core.Stories;
using DemoApp.Core.Users;
using FlatClubDemoApp.Logging;
using Unity.WebApi;

namespace FlatClubDemoApp
{
    public static class UnityConfig
    {
        #region Unity Container
        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        // ReSharper disable once ParameterHidesMember
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<UsersService>(new InjectionConstructor(container.Resolve<IUsersRepository>()));

            container.RegisterType<IStoriesRepository, StoriesRepository>();
            container.RegisterType<IStoriesService, StoriesService>();
            container.RegisterType<StoriesService>(new InjectionConstructor(
                container.Resolve<IStoriesRepository>(),
                container.Resolve<IUsersRepository>()));


            container.RegisterType<IGroupRepository, GroupRepository>();
            container.RegisterType<IGroupService, GroupService>();
            container.RegisterType<GroupService>(new InjectionConstructor(container.Resolve<IGroupRepository>()));

            container.RegisterType<ILogger, Logger>();
        }
    }
}