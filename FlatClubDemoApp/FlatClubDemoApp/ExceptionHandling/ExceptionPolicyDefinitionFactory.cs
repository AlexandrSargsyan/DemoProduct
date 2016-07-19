using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FlatClubDemoApp.ExceptionHandling
{
    internal static partial class ExceptionPolicyDefinitionFactory
    {
        public static ExceptionPolicyDefinition Create(string policyName)
        {
            if (string.IsNullOrEmpty(policyName))
            {
                throw new ArgumentException(nameof(policyName), nameof(policyName));
            }

            switch (policyName)
            {
                case ExceptionPolicyName.NotifyPolicy:
                    return ExceptionPolicyDefinitionFactory.GetNotifyPolicy();
                    
                default:
                    throw new InvalidOperationException("Invalid exception policy definition");
            }
        }
    }
}