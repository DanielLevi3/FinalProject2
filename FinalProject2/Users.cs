using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class Users
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long UserRole { set; get; }
        public Users()
        {

        }

        public Users(string userName, string password, string email, long userRole)
        {
            UserName = userName;
            Password = password;
            Email = email;
            UserRole = userRole;
        }
        public static bool operator ==(Users u1, Users u2)
        {
            if (ReferenceEquals(u1, null) && ReferenceEquals(u2, null))
            {
                return true;
            }

            if (ReferenceEquals(u1, null) || ReferenceEquals(u2, null))
            {
                return false;
            }
            if (u1.ID == u2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Users u1, Users u2)
        {
            if (!(u1.ID == u2.ID))
            {
                return true;
            }
            return false;
        }
      
        public override bool Equals(object obj)
        {
            Users other = (Users)obj;
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
