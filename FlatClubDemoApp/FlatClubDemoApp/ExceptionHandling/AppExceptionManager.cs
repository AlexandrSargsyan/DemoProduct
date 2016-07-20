using FlatClubDemoApp;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FlatClubDemoApp.ExceptionHandling
{
    internal class AppExceptionManager
    {
        internal static ExceptionManager Current
        {
            get { return AppServiceLocator.Current.GetInstance<IExceptionManagerProvider>().GetManager(); }
        }
    }
}