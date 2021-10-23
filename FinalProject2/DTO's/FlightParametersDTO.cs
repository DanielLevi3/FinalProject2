using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.DTO_s
{
   public class FlightParametersDTO
    {
        public string OriginCountryName { get; set; }
        public string DestinationCountryName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
    }
}
