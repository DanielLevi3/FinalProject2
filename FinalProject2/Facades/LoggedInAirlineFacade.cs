using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void CancelFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            if(token!=null)
            {
                if(_flightDAO!=null)
                _flightDAO.Remove(flight.ID);
                else
                {
                    _flightDAO = new FlightsDAOPGSQL();
                    _flightDAO.Remove(flight.ID);
                }
            }
        }

        public void ChangeMyPassword(LoginToken<AirlineCompanies> token, string oldPassword, string newPassword)
        {
            if (token != null)
            {
                if (oldPassword == token.User.User.Password)
                {
                    token.User.User.Password = newPassword;
                    Console.WriteLine($"Password has changed for {token.User.Name} ");
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
                if(_flightDAO!=null)
                _flightDAO.Add(flight);
                else
                {
                    _flightDAO = new FlightsDAOPGSQL();
                    _flightDAO.Add(flight);
                }
            }
        }

        public IList<Flights> GetAllFlights(LoginToken<AirlineCompanies> token)
        { 
            IList<Flights> flights = new List<Flights>();
            if (_flightDAO != null)
            {
                flights = _flightDAO.GetAll();
            }
            else
            {
                _flightDAO = new FlightsDAOPGSQL();
                flights = _flightDAO.GetAll();
            }
            return flights;
        }

        public IList<Tickets> GetAllTickets(LoginToken<AirlineCompanies> token)
        {
            List<Tickets> tickets = new List<Tickets>();
            if(token!=null)
            {
                if (_ticketDAO != null)
                    tickets = _ticketDAO.GetAll();
                else
                {
                    _ticketDAO = new TicketsDAOPGSQL();
                    tickets = _ticketDAO.GetAll();
                }
            }
            return tickets;
        }

        public void ModifyAirlineDetails(LoginToken<AirlineCompanies> token, AirlineCompanies airline)
        {
            if(token!= null)
            {
                if (_airlineDAO != null)
                    _airlineDAO.Update(airline);
                else
                {
                    _airlineDAO = new AirlineCompaniesDAOPGSQL();
                    _airlineDAO.Update(airline);
                }
            }
        }

        public void UpdateFlight(LoginToken<AirlineCompanies> token, Flights flight)
        {
            if(token!=null)
            {
                if(_flightDAO!=null)
                _flightDAO.Update(flight);
                else
                {
                    _flightDAO = new FlightsDAOPGSQL();
                    _flightDAO.Update(flight);
                }
            }
        }
    }
}
