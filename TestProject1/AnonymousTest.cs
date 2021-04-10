using FinalProject2;
using FinalProject2.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    class AnonymousTest
    {
        AnonymousUserFacade anonymousUser = new AnonymousUserFacade();
        TestingFacade testing_facade = new TestingFacade();

        [TestInitialize]
        public void ClearDB()
        {
            testing_facade.ClearDB();
        }
        [TestMethod]
        public void GetFlightByID()
        {
            Flights expected = new Flights();
        }
    }
}
