using FinalProject2;
using FinalProject2.DAO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class AdministratorTest
    {

        LoginToken<Administrator> admin = new LoginToken<Administrator>()
        {
            User = new Administrator(20, "Admin", "asd", 3, 22, new Users(22, "admin", "Test", "@", 1))
        };
        LoggedInAdministratorFacade loggedInAdministrator = new LoggedInAdministratorFacade();

        [TestInitialize]
        public void ChangeConn()
        {
            GlobalConfig.SetTestCon();
        }
        [TestMethod]
        public void GetAllCustomers()
        {
            List<Customers> expected_customers = new List<Customers>()
            {
                new Customers(1, "cus", "tomer", "ytl2", "03-23423400234", "2131313", 5),
            new Customers(2, "cusw", "tomerw", "ytle3", "03-234546234234", "231313113", 6),
        };
            List<Customers> customers2 = (List<Customers>)loggedInAdministrator.GetAllCustomers(admin);
            CollectionAssert.AreEqual(expected_customers, customers2);
        }
        
        [TestMethod]
        public void CreateNewAirline()
        {
            AirlineCompanies air = new AirlineCompanies("AirFrance1", 4, 1);
            loggedInAdministrator.CreateNewAirline(admin, air);
            AirlineCompanies air_expected= new AirlineCompanies("AirFrance1", 4, 1);
            Assert.AreEqual(air_expected, air);
        }

        [TestMethod]
        public void UpdateAirlineDetails()
        {
            AirlineCompanies air_expected = new AirlineCompanies(2,"AirFrance1", 3, 5);
            loggedInAdministrator.UpdateAirlineDetails(admin, air_expected);
            AirlineCompanies air = loggedInAdministrator.GetAirlineById(admin,2);
            Assert.AreEqual(air, air_expected);
        }

        [TestMethod]
        public void RemoveAirline()
        {
            AirlineCompanies air = loggedInAdministrator.GetAirlineById(admin,1);
            loggedInAdministrator.RemoveAirline(admin, air);
            Assert.AreEqual(0, air.ID);
        }

        [TestMethod]
        public void CreateNewCustomer()
        {
            Customers c = new Customers(3,"Daniel", "Gidon", "B Street", "000-0000000", "0000-0000-0000-0000", 1);
            loggedInAdministrator.CreateNewCustomer(admin, c);
            Customers c_expected = loggedInAdministrator.GetCustomerById(admin, 3);
            Assert.AreEqual(c_expected, c);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            Customers c = new Customers(1, "Daniel", "Gidon", "B Street", "000-0000000", "0000-0000-0000-0000", 1);
            loggedInAdministrator.UpdateCustomerDetails(admin, c);
            Customers c_ex = loggedInAdministrator.GetCustomerById(admin, 1);
            Assert.AreEqual(c_ex, c) ;
        }

        [TestMethod]
        public void RemoveCustomer()
        {
            Customers c = loggedInAdministrator.GetCustomerById(admin, 1);
            loggedInAdministrator.RemoveCustomer(admin, c);
            Assert.AreEqual(0, c.ID);
        }

        [TestMethod]
        public void CreateAdmin()
        {
            Administrator a = new Administrator("Daniel","Daniel",3,1);
            loggedInAdministrator.CreateAdmin(admin,a);
            Administrator a_expected = loggedInAdministrator.GetAdministratorById(admin, 3);
            Assert.AreEqual(a_expected, a);

        }

        [TestMethod]
        public void UpdateAdmin()
        {
            Administrator a = new Administrator(1,"Danid","kpasd",3,1);
            loggedInAdministrator.UpdateAdmin(admin, a);
            Administrator a_ex = loggedInAdministrator.GetAdministratorById(admin, 1);
            Assert.AreEqual(a_ex, a);
        }

        [TestMethod]
        public void RemoveAdmin()
        {
            Administrator a = loggedInAdministrator.GetAdministratorById(admin,1);
            loggedInAdministrator.RemoveAdmin(admin, a);
            Assert.AreEqual(0, a.ID);
        }
    }
}
