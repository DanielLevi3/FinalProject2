using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class AirlineCompanies:IPOCO,IUser
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public long UserId { get; set; }
        public Users User { get; set; }

        public AirlineCompanies()
        {

        }

        public AirlineCompanies(string name, long countryId, long userId)
        {
            Name = name;
            CountryId = countryId;
            UserId = userId;
        }

        public AirlineCompanies(long iD, string name, long countryId, long userId)
        {
            ID = iD;
            Name = name;
            CountryId = countryId;
            UserId = userId;
        }

        public static bool operator ==(AirlineCompanies ac1, AirlineCompanies ac2)
        {
            if (ReferenceEquals(ac1, null) && ReferenceEquals(ac2, null))
            {
                return true;
            }

            if (ReferenceEquals(ac1, null) || ReferenceEquals(ac2, null))
            {
                return false;
            }
            if (ac1.ID == ac2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(AirlineCompanies ac1, AirlineCompanies ac2)
        {
            if (!(ac1.ID == ac2.ID))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            AirlineCompanies other = (AirlineCompanies)obj;
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
