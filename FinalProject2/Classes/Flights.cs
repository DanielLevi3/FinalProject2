using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class Flights :IPOCO    
    {
        public long ID { get; set; }
        public long AirlineCompanyId { get; set; }
        public long OriginCountryId { get; set; }
        public long DestinationCountryId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int RemainingTickets { get; set;}
        public AirlineCompanies Airline { get; set; }
        public Flights()
        {

        }

        public Flights(long airlineCompanyId, long originCountryId, long destinationCountryId, DateTime departureTime, DateTime landingTime, int remainingTickets)
        {
            AirlineCompanyId = airlineCompanyId;
            OriginCountryId = originCountryId;
            DestinationCountryId = destinationCountryId;
            DepartureTime = departureTime;
            LandingTime = landingTime;
            RemainingTickets = remainingTickets;
        }
        public static bool operator ==(Flights f1, Flights f2)
        {
            if (ReferenceEquals(f1, null) && ReferenceEquals(f2, null))
            {
                return true;
            }

            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null))
            {
                return false;
            }
            if (f1.ID == f2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Flights f1, Flights f2)
        {
            if (!(f1.ID == f2.ID))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            Flights other = (Flights)obj;
            return this.ID == other.ID;
        }

        public override int GetHashCode()
        {

            return (int)this.ID;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
