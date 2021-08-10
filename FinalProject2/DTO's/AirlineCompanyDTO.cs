using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2.DTO_s
{
    public class AirlineCompanyDTO  // destination
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
        public long UserId { get; set; }
        public Users User { get; set; }
    }
}
