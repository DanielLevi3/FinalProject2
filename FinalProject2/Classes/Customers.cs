using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public class Customers:IPOCO,IUser
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CreditNumber { get; set; }
        public long UserId { get; set; }
        public Users User { get; set; }

        public Customers()
        {

        }

        public Customers(string firstName, string lastName, string address, string phoneNumber, string creditNumber, long userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            CreditNumber = creditNumber;
            UserId = userId;
        }

        public static bool operator ==(Customers c1, Customers c2)
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
        public static bool operator !=(Customers c1, Customers c2)
        {
            if (!(c1.ID == c2.ID))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            Customers other = (Customers)obj;
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
