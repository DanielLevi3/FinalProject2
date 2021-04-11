using FinalProject2;
using FinalProject2.DAO_s;
using FinalProject2.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
   public class AnonymousTest
    {
        AnonymousUserFacade anonymousUser = new AnonymousUserFacade();
        TestingFacade testing_facade = new TestingFacade();

        [TestInitialize]
        public void ChangeConn()
        {
            GlobalConfig.SetTestCon();
        }
        
        [TestMethod]
        public void GetFlightByID()
        {
            Flights f = anonymousUser.GetFlightById(1);
            Flights expected = new Flights(1, 3, 3, 6, DateTime.Now, new DateTime(2021, 04, 26), 10);
            Assert.AreEqual(f, expected);
        }
        [TestMethod]
        public void GetAllFlights()
        {
            IList<Flights> flights = anonymousUser.GetAllFlights();
            IList<Flights> expected = new List<Flights>()
            {
              new Flights(1, 3, 3, 6, DateTime.Now, new DateTime(2021, 04, 26), 10),
               new Flights(2, 4, 5, 2, DateTime.Now, new DateTime(2021, 04, 17), 23)
            };
            Assert.AreEqual(flights, expected);
        }
    }
}
