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
       
        [TestInitialize]
        public void ChangeConn()
        {
            GlobalConfig.SetTestCon();
        }
        
        [TestMethod]
        public void GetFlightByID()
        {
            Flights f = anonymousUser.GetFlightById(1);
            Flights expected = new Flights(1, 1, 3, 6, new DateTime(2021, 03, 26), new DateTime(2021, 04, 26), 10);
            Assert.AreEqual(f, expected);
        }
        [TestMethod]
        public void GetAllFlights()
        {
            List<Flights> flights = (List<Flights>)anonymousUser.GetAllFlights();
            List<Flights> expected = new List<Flights>()
            {
              new Flights(1,1, 3, 6, new DateTime(2021,03, 26), new DateTime(2021,04,26), 10),
               new Flights(2,2, 5, 2, new DateTime(2021, 01, 17), new DateTime(2021, 04, 17), 23)
            };
            CollectionAssert.AreEqual(expected, flights);
        }
        [TestMethod]
        public void GetAllAirelineCompanies()
        {
            AirlineCompanies expected = new AirlineCompanies(1,"airone", 3, 3);
            AirlineCompanies expected2 = new AirlineCompanies(2,"airtwo", 5, 4);
            List<AirlineCompanies> Expectedlist = new List<AirlineCompanies>();
            Expectedlist.Add(expected);
            Expectedlist.Add(expected2);
            List<AirlineCompanies> airlineCompanies = (List<AirlineCompanies>)anonymousUser.GetAllAirlineCompanies();
            CollectionAssert.AreEqual(Expectedlist, airlineCompanies);
        }
        [TestMethod]
        public void GetAllFlightsVacancy()
        {
            Flights expectedF = new Flights(1, 1, 3, 6, new DateTime(2021, 03, 26), new DateTime(2021, 04, 26), 10);
            Flights expectedF3 = new Flights(2, 2, 5, 2, new DateTime(2021, 01, 17), new DateTime(2021, 04, 17), 23);
            Dictionary<Flights, int> flight_vacancy = new Dictionary<Flights, int>();
            flight_vacancy = anonymousUser.GetAllFlightsVacancy();
            Dictionary<Flights, int> flight_vacancy_expected = new Dictionary<Flights, int>();
            flight_vacancy_expected.Add(expectedF, 10);
            flight_vacancy_expected.Add(expectedF3,23);
           CollectionAssert.AreEqual(flight_vacancy_expected, flight_vacancy);
        }
        [TestMethod]
        public void GetFlightsByDepartureDate()
        {
            Flights expectedF = new Flights(1, 1, 3, 6, new DateTime(2021, 03, 26), new DateTime(2021, 04, 26), 10);
            List<Flights> expectedlis = new List<Flights>();
            expectedlis.Add(expectedF);
            List<Flights> f = (List<Flights>)anonymousUser.GetFlightsByDepatrureDate(new DateTime(2021, 03, 26));
            CollectionAssert.AreEqual(expectedlis, f);
        }
        [TestMethod]
        public void GetFlightsByLandingDate()
        {
            Flights expectedF = new Flights(1, 1, 3, 6, new DateTime(2021, 03, 26), new DateTime(2021, 04, 26), 10);
            List<Flights> expectedlis = new List<Flights>();
            expectedlis.Add(expectedF);
            List<Flights> f = (List<Flights>)anonymousUser.GetFlightsByLandingDate(new DateTime(2021, 04, 26));
            CollectionAssert.AreEqual(expectedlis, f);
        }
        [TestMethod]
        public void GetFlightsByOriginCountry()
        {
            Flights expectedF = new Flights(1, 1, 3, 6, new DateTime(2021, 03, 26), new DateTime(2021, 04, 26), 10);
            List<Flights> expectedlis = new List<Flights>();
            expectedlis.Add(expectedF);
            List<Flights> f = (List<Flights>)anonymousUser.GetFlightsByOriginCountry(3);
            CollectionAssert.AreEqual(expectedlis, f);
        }
        [TestMethod]
        public void GetFlightsByDestinationCountry()
        {
            Flights expectedF = new Flights(1, 1, 3, 6, new DateTime(2021, 03, 26), new DateTime(2021, 04, 26), 10);
            List<Flights> expectedlis = new List<Flights>();
            expectedlis.Add(expectedF);
            List<Flights> f = (List<Flights>)anonymousUser.GetFlightsByDestinationCountry(6);
            CollectionAssert.AreEqual(expectedlis, f);
        }
    }
}
