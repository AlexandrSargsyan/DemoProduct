using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace FlatClubDemoApp
{
    internal class AppServiceLocator
    {
#pragma warning disable CC0033 // Dispose Fields Properly
        private static readonly UnityServiceLocator сurrentUnityServiceLocator =
#pragma warning restore CC0033 // Dispose Fields Properly
            new UnityServiceLocator(UnityConfig.GetConfiguredContainer());

        
        public static UnityServiceLocator Current => сurrentUnityServiceLocator;
    }
}