using Prueba.Web.Models;
using System.Linq.Expressions;

namespace Prueba.Web.Repositories.Interfaces
{
    public interface IFibonacciNumbersServices
    {
        Task<bool> AnyNumberAsync(long i);

        Task<bool> AddAsync(FibonacciNumber fibonacciNumber);
    }
}
