using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public void CancelFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            if(token!=null)
            {
                _flightDAO.Remove(flight.ID);
            }
        }

        public void ChangeMyPassword(LoginToken<AirlineCompanies> token, string oldPassword, string newPassword)
        {
            if (token != null)
            {
                if (oldPassword == token.User.User.Password)
                {
                    token.User.User.Password = newPassword;
                    Console.WriteLine($"Password has for {token.User.Name} changed");
                }
                else
                {
                    throw new WrongPasswordExeception("The old password is incorrect please try again");
                }
            }
        }

        public void CreateFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
           if(token!=null)
            {
                _flightDAO.Add(flight);
            }
        }

        public IList<Flights> GetAllFlights(LoginToken<AirlineCompanies> token)
        { 
            IList<Flights> flights = new List<Flights>();
            if(token!=null)
            {
                foreach (Flights item in flights)
                {
                    _flightDAO.GetById(item.ID);
                }
            }
            return flights;
        }

        public IList<Tickets> GetAllTickets(LoginToken<AirlineCompanies> token)
        {
            List<Tickets> tickets = new List<Tickets>();
            if(token!=null)
            {
               tickets= _ticketDAO.GetAll();
            }
            return tickets;
        }

        public void ModifyAirlineDetails(LoginToken<AirlineCompanies> token, AirlineCompanies airline)
        {
            if(token!= null)
            {
                _airlineDAO.Update(airline);
            }
        }

        public void UpdateFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            if(token!=null)
            {
                _flightDAO.Update(flight);
            }
        }
    }
}
