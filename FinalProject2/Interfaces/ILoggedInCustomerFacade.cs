﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface ILoggedInCustomerFacade
    {
        IList<Flights> GetAllMyFlights(LoginToken<Customers> token);
        Tickets PurchaseTicket(LoginToken<Customers> token, Flights flight);
        void CancelTicket(LoginToken<Customers> token, Tickets ticket);
        Dictionary<long, long> GetAllTicketsIdByFlightsId(LoginToken<Customers> token, IList<Flights> flights);

    }
}
