using FinalProject2;
using FinalProject2.DAO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class CustomerTest
    {
        LoginToken<Customers> cus = new LoginToken<Customers>()
        {
            User = new Customers(10, "cus", "tomer", "asdasd", "0505131", "1321654", 25, new Users(25, "cusss", "Tomer", "@", 3))
        };
        LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade();

        [TestInitialize]
        public void ChangeConn()
        {
            GlobalConfig.SetTestCon();
        }

        [TestMethod]
        public void GetAllFlights()
        {
            List<Flights> flights = (List<Flights>)customerFacade.GetAllMyFlights(cus);
            List<Flights> expected = new List<Flights>()
            {
              new Flights(1,1, 3, 6, new DateTime(2021,03, 26), new DateTime(2021,04,26), 10),
               new Flights(2,2, 5, 2, new DateTime(2021, 01, 17), new DateTime(2021, 04, 17), 23)
            };
            CollectionAssert.AreEqual(expected, flights);
        }
        [TestMethod]
        public void PurchaseTicket()
        {
            Flights f = customerFacade.GetFlightById(1);
            Tickets a = customerFacade.PurchaseTicket(cus, f);
            Tickets ex = new Tickets(10, 1);
            Assert.AreEqual(ex, a);
        }
        [TestMethod]
        public void CancelTicket()
        {
            Flights f = customerFacade.GetFlightById(1);
            Tickets t = customerFacade.PurchaseTicket(cus, f);
            customerFacade.CancelTicket(cus, t);
            Assert.AreEqual(0, t.ID);
        }
        //  IList<Flight> GetAllMyFlights(LoginToken<Customer> token);
        // Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight);
        // void CancelTicket(LoginToken<Customer> token, Ticket ticket);
    }
}
