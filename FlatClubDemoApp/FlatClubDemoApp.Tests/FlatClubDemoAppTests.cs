using System;
using System.Diagnostics;
using DataAccess.Groups;
using DemoApp.Commonm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlatClubDemoApp.Tests
{
    [TestClass]
    public class FlatClubDemoAppTests
    {
        [TestMethod]
        public void HashTest()
        {
            var test = HashingUtility.GetHash("123");
            Debug.WriteLine(test);

        }

        [TestMethod]
        public void GroupTest()
        {

        }
    }
}
