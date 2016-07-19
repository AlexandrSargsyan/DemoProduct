using FlatClubDemoApp;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FlatClubDemoApp.ExceptionHandling
{
    internal class AppExceptionManager
    {
        internal static ExceptionManager Current => AppServiceLocator.Current.GetInstance<IExceptionManagerProvider>().GetManager();
    }
}