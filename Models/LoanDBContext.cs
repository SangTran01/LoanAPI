using Microsoft.EntityFrameworkCore;

namespace LoanWebAPI.Models
{
    public class LoanDBContext: DbContext
    {
        public LoanDBContext(DbContextOptions<LoanDBContext> options) : base(options) { }

        public DbSet<Loan> Loans { get; set; }
    }
}
