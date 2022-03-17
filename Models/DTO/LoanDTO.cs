using System.ComponentModel.DataAnnotations;

namespace LoanWebAPI.Models.DTO
{
    public class LoanDTO
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Institution { get; set; }

        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]

        public decimal Amount { get; set; }
    }
}
