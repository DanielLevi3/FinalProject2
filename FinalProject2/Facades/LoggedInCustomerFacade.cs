﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customers> token, Tickets ticket)
        {
            if (token != null)
            {
                if (_ticketDAO != null)
                    _ticketDAO.Remove(ticket.ID);
                else
                {
                    _ticketDAO = new TicketsDAOPGSQL();
                    _ticketDAO.Remove(ticket.ID);
                }
            }
        }

        public IList<Flights> GetAllMyFlights(LoginToken<Customers> token)
        {
            IList<Flights> flights = new List<Flights>();
            if (token != null)
            {
                if (_flightDAO != null)
                    flights = _flightDAO.GetFlightsByCustomerId(token.User.ID);
                else
                {
                    _flightDAO = new FlightsDAOPGSQL();
                    flights = _flightDAO.GetFlightsByCustomerId(token.User.ID);
                }
            }
            return flights;
        }

        public Tickets PurchaseTicket(LoginToken<Customers> token, Flights flight)
        {
            Tickets ticket = new Tickets();
            if (token != null)
            {
                ticket.CustomerID = token.User.ID;
                ticket.FlightID = flight.ID;
                ticket.Customer = token.User;
                ticket.Flight = flight;
            }
            return ticket;
        }
        public Customers GetCustomerDetails(LoginToken<Customers> token)
        {
            Customers c = new Customers();
            if (token != null)
            {
                if (_customerDAO != null)
                {
                    c = _customerDAO.GetById(token.User.ID);
                    c.User = token.User.User;
                }
                else
                {
                    _customerDAO = new CustomersDAOPGSQL();
                    c = _customerDAO.GetById(token.User.ID);
                }
            }
            return c;
        }
        public void UpdateCustomer(LoginToken<Customers> token, Customers c)
        {
            if (token != null)
            {
                if (_customerDAO != null && _userDAO != null)
                {
                    _customerDAO.Update(c);
                    _userDAO.Update(c.User);
                }
                else
                {
                    _customerDAO = new CustomersDAOPGSQL();
                    _userDAO = new UsersDAOPGSQL();
                    _customerDAO.Update(c);
                    _userDAO.Update(c.User);
                }
            }
        }
        public Dictionary<long, long> GetAllTicketsIdByFlightsId(LoginToken<Customers> token, IList<Flights> flights)
        {
            Dictionary<long, long> mapFlightsToTickets = new Dictionary<long, long>();
            if (token != null)
            {
                if(_ticketDAO != null && _flightDAO != null)
                { 
                List<Tickets> tickets =_ticketDAO.GetAll();
                List<Flights> flightsLst = _flightDAO.GetAll();
                    tickets.ForEach(ticket =>
                    {
                        Flights f = flightsLst.Find(f => f.ID == ticket.FlightID);
                        mapFlightsToTickets.Add(f.ID, ticket.ID);
                    });
                    return mapFlightsToTickets;
                }
                else
                {
                    _flightDAO = new FlightsDAOPGSQL();
                    _ticketDAO = new TicketsDAOPGSQL();
                    List<Tickets> tickets = _ticketDAO.GetAll();
                    List<Flights> flightsLst = _flightDAO.GetAll();
                    flightsLst.ForEach(flight =>
                    {
                        Tickets ticket = tickets.Find(tick => tick.FlightID == flight.ID);
                        mapFlightsToTickets.Add(flight.ID, ticket.ID);
                    });
                    return mapFlightsToTickets;
                }
            }
            return mapFlightsToTickets;
        }
    }
}
