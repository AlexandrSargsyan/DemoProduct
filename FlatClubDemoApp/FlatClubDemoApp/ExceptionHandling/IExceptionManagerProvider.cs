using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FlatClubDemoApp.ExceptionHandling
{
    public interface IExceptionManagerProvider
    {
        ExceptionManager GetManager();
    }
}