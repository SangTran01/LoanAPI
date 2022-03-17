using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanWebAPI.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Institution { get; set; }
        public decimal Amount { get; set; }
    }
}
