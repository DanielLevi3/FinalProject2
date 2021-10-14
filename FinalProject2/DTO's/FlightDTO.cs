using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.DTO_s
{
   public class FlightDTO
    {
        public long ID { get; set; }
        public string AirlineCompanyName { get; set; }
        public string OriginCountryName { get; set; }
        public string DestinationCountryName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemainingTickets { get; set; }
        public long TicketId { get; set; }
    }
}
