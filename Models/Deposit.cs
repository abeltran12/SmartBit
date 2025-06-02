using SmartBit.Data;

namespace SmartBit.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Deposit
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Deposit), nameof(ValidateDate))]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Amount must have up to 2 decimal places.")]
        public double Amount { get; set; }

        public MonetaryFund MonetaryFund { get; set; }

        [Required]
        [Range(typeof(Guid), "00000001-0000-0000-0000-000000000000", "ffffffff-ffff-ffff-ffff-ffffffffffff",
        ErrorMessage = "Please select a valid Monetary Fund")]
        public Guid MonetaryFundId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;

        [NotMapped]
        [JsonIgnore]
        public string MonetaryFundName { get; set; } = string.Empty;

        public static ValidationResult? ValidateDate(DateTime date, ValidationContext context)
        {
            if (date.Year <= 2000)
            {
                return new ValidationResult("Date must be after the year 2000.");
            }
            return ValidationResult.Success;
        }
    }
}