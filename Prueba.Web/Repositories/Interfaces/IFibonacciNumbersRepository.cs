using Prueba.Web.Models;
using System.Linq.Expressions;

namespace Prueba.Web.Repositories.Interfaces
{
    public interface IFibonacciNumbersRepository
    {
        Task<bool> AnyAsync(Expression<Func<FibonacciNumber, bool>> arg);

        Task<bool> AddAsync(FibonacciNumber fibonacciNumber);
    }
}
