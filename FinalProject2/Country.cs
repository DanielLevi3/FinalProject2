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
        public Country()
        {

        }

        public override bool Equals(object obj)
        {
            // find out first if not null
            return this.ID == ((Country)obj).ID;
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
