using LoanWebAPI.Models;

namespace LoanWebAPI.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Loan, int> LoanRepository { get; }
        Task<bool> SaveAsync();
    }
}
