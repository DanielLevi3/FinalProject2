using FinalProject2;
using FinalProject2.DAO_s;
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
        public void ChangeConn()
        {
            GlobalConfig.SetTestCon();
            ClearDB();
        }
        public void ClearDB()
        {
            testingFacade.ClearDB();
        }
        [TestMethod]
        public void InsertData()
        {
            LoginToken<Administrator> admin = new LoginToken<Administrator>()
            {
                User = new Administrator(0,"Admin", "Test", 3,0,new Users(0,"admin","Test","@",1))
            };
            LoggedInAdministrator.CreateNewUser(admin, new Users(1,"admin1", "pass", "something@gmail.com",1));
            LoggedInAdministrator.CreateNewUser(admin, new Users(2,"admin2", "pass", "something1@gmail.com", 1));
            LoggedInAdministrator.CreateNewUser(admin, new Users(3,"airline1", "pass", "something2@gmail.com", 2));
            LoggedInAdministrator.CreateNewUser(admin, new Users(4,"airline2", "pass", "something3@gmail.com", 2));
            LoggedInAdministrator.CreateNewUser(admin, new Users(5,"customer1", "pass", "something4@gmail.com", 3));
            LoggedInAdministrator.CreateNewUser(admin, new Users(6,"customer2", "pass", "something5@gmail.com", 3));

            LoggedInAdministrator.CreateAdmin(admin, new Administrator(1,"simi", "simi", 2, 1));
            LoggedInAdministrator.CreateAdmin(admin, new Administrator(2,"bibi", "simi", 3, 2));
            LoggedInAdministrator.CreateNewAirline(admin,new AirlineCompanies(1,"airone",3,3));
            LoggedInAdministrator.CreateNewAirline(admin, new AirlineCompanies(2,"airtwo", 5, 4));
            LoggedInAdministrator.CreateNewCustomer(admin, new Customers(1,"cus", "tomer", "ytl2", "03-23423400234", "2131313", 5));
            LoggedInAdministrator.CreateNewCustomer(admin, new Customers(2,"cusw", "tomerw", "ytle3", "03-234546234234", "231313113", 6));

            loggedInAirline.CreateFlight(new LoginToken<AirlineCompanies>(), new Flights(1,1, 3, 6, new DateTime(2021,03, 26), new DateTime(2021,04,26), 10));
            loggedInAirline.CreateFlight(new LoginToken<AirlineCompanies>(), new Flights(2,2, 5, 2, new DateTime(2021, 01, 17), new DateTime(2021, 04, 17), 23));
            LoggedInAdministrator.CreateNewTicket(admin, new Tickets(1, 1));
            LoggedInAdministrator.CreateNewTicket(admin, new Tickets(2, 2));

        }
    }
}
