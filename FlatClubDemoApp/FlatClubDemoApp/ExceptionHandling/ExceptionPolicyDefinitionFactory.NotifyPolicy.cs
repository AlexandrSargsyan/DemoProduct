using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FlatClubDemoApp.ExceptionHandling
{
    internal static partial class ExceptionPolicyDefinitionFactory
    {
        internal static ExceptionPolicyDefinition GetNotifyPolicy()
        {
            return new ExceptionPolicyDefinition(
                ExceptionPolicyName.NotifyPolicy,
                new Dictionary<Type, ExceptionPolicyEntry>());
        }
    }
}