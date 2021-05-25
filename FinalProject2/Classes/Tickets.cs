using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
     public class Tickets:IPOCO
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public long FlightID { get; set;}
        public Customers Customer { get; set; }
        public Flights Flight { get; set; }

        public Tickets()
        {

        }
        public Tickets(long customerID, long flightID)
        {
            CustomerID = customerID;
            FlightID = flightID;
        }

        public Tickets(long iD, long customerID, long flightID) : this(iD, customerID)
        {
            FlightID = flightID;
        }

        public static bool operator ==(Tickets t1, Tickets t2)
        {
            if (ReferenceEquals(t1, null) && ReferenceEquals(t2, null))
            {
                return true;
            }

            if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null))
            {
                return false;
            }
            if (t1.ID == t2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Tickets t1, Tickets t2)
        {
            if (!(t1.ID == t2.ID))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            Tickets other = (Tickets)obj;
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
