using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalProject2.DTO_s
{
    public class UserDetailsDTO
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Password { get; set; }
    }
}
