using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.DTO_s
{
   public class FlightDTO
    {
        public long ID;
        public string AirlineCompanyName;
        public string OriginCountryName;
        public string DestinationCountryName;
        public DateTime DepartureTime;
        public DateTime LandingTime;
        public int RemainingTickets;
        public long TicketId;
    }
}
