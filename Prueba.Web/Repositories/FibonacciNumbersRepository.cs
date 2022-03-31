using Microsoft.EntityFrameworkCore;
using Prueba.Web.Data;
using Prueba.Web.Models;
using Prueba.Web.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Prueba.Web.Repositories
{
    public class FibonacciNumbersRepository : IFibonacciNumbersRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FibonacciNumbersRepository(ApplicationDbContext dbcontext)
        {
            _applicationDbContext = dbcontext;
        }

        public async Task<bool> AnyAsync(Expression<Func<FibonacciNumber, bool>> arg)
        {
            return await _applicationDbContext.FibonacciNumbers.AnyAsync(arg);
        }

        public async Task<bool> AddAsync(FibonacciNumber fibonacciNumber)
        {
            await _applicationDbContext.FibonacciNumbers.AddAsync(fibonacciNumber);
            return await _applicationDbContext.SaveChangesAsync() == 1;
        }
    }
}
