using LoanWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LoanWebAPI.Repository
{
    public interface IRepository<T, T2> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<T?> FindById(T2 id);
        Task<T> Add(T entity);
        Task Delete(T entity);
    }
}
