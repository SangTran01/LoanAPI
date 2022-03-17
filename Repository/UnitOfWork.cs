using LoanWebAPI.Models;

namespace LoanWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoanDBContext _loanDBContext;
        private LoanRepository _loanRepository;

        public UnitOfWork(LoanDBContext loanDBContext)
        {
            _loanDBContext = loanDBContext;
        }

        public IRepository<Loan, int> LoanRepository {
            get {
                if (_loanRepository == null) {
                    _loanRepository = new LoanRepository(_loanDBContext);
                }
                return _loanRepository;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _loanDBContext.SaveChangesAsync() > 0;
        }
    }
}
