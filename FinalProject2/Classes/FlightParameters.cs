using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.Classes
{
   public class FlightParameters
    {
        public long OriginCountryId { get; set; }
        public long DestinationCountryId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public FlightParameters()
        {

        }

        public FlightParameters(long originCountryId, long destinationCountryId, DateTime departureTime, DateTime landingTime)
        {
            OriginCountryId = originCountryId;
            DestinationCountryId = destinationCountryId;
            DepartureTime = departureTime;
            LandingTime = landingTime;
        }
       
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
   