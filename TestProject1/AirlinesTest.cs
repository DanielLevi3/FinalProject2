using FinalProject2;
using FinalProject2.DAO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class AirlinesTest
    {
        LoginToken<AirlineCompanies> airline = new LoginToken<AirlineCompanies>()
        {
            User=new AirlineCompanies(1,"dasd",1,20,new Users(20,"air","1234","emils",2))
        };
        LoggedInAirlineFacade loggedInAirline = new LoggedInAirlineFacade();

        [TestInitialize]
        public void ChangeConn()
        {
            GlobalConfig.SetTestCon();
        }
        [TestMethod]
        public void GetAllTickets()
        {
            List<Tickets> expected_tickets = new List<Tickets>();// neec to check what went wrong
            Tickets a = new Tickets( 1, 1);
            Tickets b = new Tickets( 2, 2);
            a.ID = 1;
            b.ID = 2;
            expected_tickets.Add(a);
            expected_tickets.Add(b);
            List<Tickets> tickets =(List<Tickets>)loggedInAirline.GetAllTickets(airline);
            CollectionAssert.AreEqual(expected_tickets, tickets);
        }
        [TestMethod]
        public void CancelFlight()
        {
            Flights f = loggedInAirline.GetFlightById(2);
            loggedInAirline.CancelFlight(airline, f);
            Assert.AreEqual(0,f.ID);//Modify the DAOclasses that will contain a list of objects that will deleted or added in the functions for the object will be null
        }
        [TestMethod]
        public void CreateFlight()
        {
            Flights f = new Flights(1, 4, 5, DateTime.Now, new DateTime(2021, 05, 30), 54);
            loggedInAirline.CreateFlight(airline, f);
            Flights f_expected = new Flights(1, 4, 5, DateTime.Now, new DateTime(2021, 05, 30), 54);
            Assert.AreEqual(f_expected, f);

        }
        [TestMethod]
        public void UpdateFlight()
        {
            Flights f_expected = new Flights(1,1,4,7, DateTime.Now, new DateTime(2021, 07,20),4);
            loggedInAirline.UpdateFlight(airline, f_expected);//not working well throws exception even though the test is positive
            Flights f = loggedInAirline.GetFlightById(1);
            Assert.AreEqual(f_expected, f);
        }
        [TestMethod]
        public void ChangeMyPassword()
        {
            loggedInAirline.ChangeMyPassword(airline,"1234" ,"54321");
            Assert.AreEqual(airline.User.User.Password, "54321");
        }
        [TestMethod]
        public void ModifyAirlineDetails()
        {
            AirlineCompanies air = new AirlineCompanies(1, "airforce", 3, 3);
            loggedInAirline.ModifyAirlineDetails(airline, air);
            AirlineCompanies air_for_test = loggedInAirline.GetAirlineById(airline,1);
            Assert.AreEqual(air, air_for_test);
        }
    }
}
