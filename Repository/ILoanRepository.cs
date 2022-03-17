using LoanWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LoanWebAPI.Repository
{
    public interface ILoanRepository<T, T2> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<T?> FindById(T2 id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Save();
    }
}
