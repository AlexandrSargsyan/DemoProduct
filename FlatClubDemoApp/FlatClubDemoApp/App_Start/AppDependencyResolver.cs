﻿using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using FlatClubDemoApp.Logging;
using Microsoft.Practices.Unity;

namespace FlatClubDemoApp
{
    public class AppDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;
        private readonly ILogger logger;

        public AppDependencyResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.logger = AppServiceLocator.Current.GetInstance<ILogger>();

            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }

            catch (ResolutionFailedException ex)
            {
                logger.Write(ex);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
              logger.Write(ex);
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = this.container.CreateChildContainer();
            return new AppDependencyResolver(child);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }
    }
}