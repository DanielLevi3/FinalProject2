using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class Country :IPOCO
    {
        public long ID { get; set; }
        public string Name { get; set; } 

        public Country(string name)
        {
            Name = name;
        }
        public Tickets()
        {

        }
        public static bool operator ==(Country c1, Country c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
            {
                return true;
            }

            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            if (c1.ID == c2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Country c1, Country c2)
        {
            if (!(c1.ID == c2.ID))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            Country other = (Country)obj;
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
