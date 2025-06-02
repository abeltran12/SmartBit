using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SmartBit.Data;

namespace SmartBit.Models
{
    public class MonetaryFund
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters long")]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        public TypeMonetaryFund Type { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;

        public bool Active { get; set; }
    }
}