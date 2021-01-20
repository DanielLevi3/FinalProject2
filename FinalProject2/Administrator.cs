using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    class Administrator:IPOCO
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
