using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FlatClubDemoApp.ExceptionHandling
{
    public class DefaultExceptionManagerProvider : IExceptionManagerProvider
    {
        public ExceptionManager GetManager()
        {
            return new ExceptionManager(GetExceptionPolicyDefinitions());
        }

        private static IEnumerable<ExceptionPolicyDefinition> GetExceptionPolicyDefinitions()
        {
            var policyDefinitions = new List<ExceptionPolicyDefinition>
            {
                ExceptionPolicyDefinitionFactory.Create(ExceptionPolicyName.NotifyPolicy)
            };

            return policyDefinitions;
        }
    }
}