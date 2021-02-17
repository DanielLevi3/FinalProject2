using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public void CancelTicket(LoginToken<Customers> token, Tickets ticket)
        {
            throw new NotImplementedException();
        }

        public IList<Flights> GetAllMyFlights(LoginToken<Customers> token)
        {
            throw new NotImplementedException();
        }

        public Tickets PurchaseTicket(LoginToken<Customers> token, Flights flight)
        {
            throw new NotImplementedException();
        }
    }
}
