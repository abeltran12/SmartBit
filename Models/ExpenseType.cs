using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBit.Models
{
    public class ExpenseType
    {
        [Key]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(4, ErrorMessage = "Name must be at least 4 characters.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(4, ErrorMessage = "Description must be at least 4 characters.")]
        [MaxLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; } = string.Empty;

        public bool Active { get; set; }
    }
}