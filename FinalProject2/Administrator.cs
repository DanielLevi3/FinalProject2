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

        public Administrator()
        {

        }

        public Administrator(string firstName, string lastName, int level)
        {
            FirstName = firstName;
            LastName = lastName;
            Level = level;
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
