﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class Administrator:IPOCO,IUser
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public long User_id { get; set;}
        public Users User { get; set; }
        public Administrator()
        {

        }

        public Administrator(string firstName, string lastName, int level,long user_id)
        {
            FirstName = firstName;
            LastName = lastName;
            Level = level;
            User_id = user_id;
        }
        public static bool operator ==(Administrator a1, Administrator a2)
        {
            if (ReferenceEquals(a1, null) && ReferenceEquals(a2, null))
            {
                return true;
            }

            if (ReferenceEquals(a1, null) || ReferenceEquals(a2, null))
            {
                return false;
            }
            if (a1.ID == a2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Administrator a1, Administrator a2)
        {
            if (!(a1.ID == a2.ID))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            Administrator other = (Administrator)obj;
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
