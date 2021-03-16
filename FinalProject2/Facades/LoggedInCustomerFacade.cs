using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customers> token, Tickets ticket)
        {
            if(token!=null)
            {
                _ticketDAO.Remove(ticket.ID);
            }
        }

        public IList<Flights> GetAllMyFlights(LoginToken<Customers> token)
        {
            IList<Flights> flights = new List<Flights>();
            if(token!=null)
            {
              flights = _flightDAO.GetAll();
            }
            return flights;
        }

        public Tickets PurchaseTicket(LoginToken<Customers> token, Flights flight)
        {
            Tickets ticket = new Tickets();
            if (token!=null)
            {
                ticket.CustomerID = token.User.ID;
                ticket.FlightID = flight.ID;
                ticket.Customer = token.User;
                ticket.Flight = flight;
            }
            return ticket;
        }
    }
}
