using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
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
                Users u = new Users();
                u = _userDAO.GetById(token.User.ID);
                if(u.Password==oldPassword)
                {
                    u.Password = newPassword;
                    Console.WriteLine("Password has changed");
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

        public IList<Tickets> GetAllFlights(LoginToken<AirlineCompanies> token)
        {
            // לא סיימתי את זה צריך לעבור על זה 
            IList<Tickets> tickets= new List<Tickets>();
            if(token!=null)
            {
                foreach (Tickets item in tickets)
                {
                    _flightDAO.GetById(item.FlightID);
                }
            }
            return tickets;
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
