using FinalProject2;
using FinalProject2.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestingProj
    {
        TestingFacade testingFacade = new TestingFacade();
        LoggedInAirlineFacade loggedInAirline = new LoggedInAirlineFacade();
        LoggedInAdministratorFacade LoggedInAdministrator = new LoggedInAdministratorFacade();
        
        [TestInitialize]
        public void ClearDB()
        {
            testingFacade.ClearDB();
        }
        [TestMethod]
        public void InsertData()
        {
            LoginToken<Administrator> admin = new LoginToken<Administrator>()
            {
                User = new Administrator("Admin", "Test", 3, 20)
            };
            LoggedInAdministrator.CreateNewUser(admin, new Users("admin1", "pass", "something@gmail.com", 1));
            LoggedInAdministrator.CreateNewUser(admin, new Users("admin2", "pass", "something@gmail.com", 2));
            LoggedInAdministrator.CreateNewUser(admin, new Users("airline1", "pass", "something@gmail.com", 3));
            LoggedInAdministrator.CreateNewUser(admin, new Users("airline2", "pass", "something@gmail.com", 4));
            LoggedInAdministrator.CreateNewUser(admin, new Users("customer1", "pass", "something@gmail.com", 5));
            LoggedInAdministrator.CreateNewUser(admin, new Users("customer2", "pass", "something@gmail.com", 6));

            LoggedInAdministrator.CreateAdmin(admin, new Administrator(1,"simi", "simi", 2, 1));
            LoggedInAdministrator.CreateAdmin(admin, new Administrator(2,"bibi", "simi", 3, 2));
            LoggedInAdministrator.CreateNewAirline(admin,new AirlineCompanies(1,"airone",3,3));
            LoggedInAdministrator.CreateNewAirline(admin, new AirlineCompanies(2,"airtwo", 5, 4));
            LoggedInAdministrator.CreateNewCustomer(admin, new Customers(1,"cus", "tomer", "ytl2", "03-234234234", "2131313", 5));
            LoggedInAdministrator.CreateNewCustomer(admin, new Customers(2,"cusw", "tomerw", "ytle3", "03-234234234", "23131313", 6));

            loggedInAirline.CreateFlight(new LoginToken<AirlineCompanies>(), new Flights(1,3, 3, 6, DateTime.Now, new DateTime(2021,04,26), 10));
            loggedInAirline.CreateFlight(new LoginToken<AirlineCompanies>(), new Flights(2,4, 5, 2, DateTime.Now, new DateTime(2021, 04, 17), 23));
            LoggedInAdministrator.CreateNewTicket(admin, new Tickets(1, 1));
            LoggedInAdministrator.CreateNewTicket(admin, new Tickets(2, 2));

        }
    }
}
