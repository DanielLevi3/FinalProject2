using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    interface ILoggedInCustomerFacade
    {
        IList<Flights> GetAllMyFlights(LoginToken<Customers> token);
        Tickets PurchaseTicket(LoginToken<Customers> token, Flights flight);
        void CancelTicket(LoginToken<Customers> token, Tickets ticket);
    }
}
