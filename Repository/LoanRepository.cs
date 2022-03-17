using LoanWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace LoanWebAPI.Repository
{
    public class LoanRepository : IRepository<Loan,int>
    {
        private readonly LoanDBContext _loanDBContext;

        public LoanRepository(LoanDBContext loanDBContext)
        {
            _loanDBContext = loanDBContext;
        }

        public async Task<Loan> Add(Loan entity)
        {
            await _loanDBContext.Loans.AddAsync(entity);
            return entity;
        }

        public async Task Delete(Loan entity)
        {
            _loanDBContext.Loans.Remove(entity);
        }

        public async Task<IEnumerable<Loan>> FindAll()
        {
            return await _loanDBContext.Loans.ToListAsync();
        }

        public async Task<Loan?> FindById(int id)
        {
            return await _loanDBContext.Loans.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
