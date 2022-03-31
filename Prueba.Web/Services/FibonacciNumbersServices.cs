using Microsoft.EntityFrameworkCore;
using Prueba.Web.Data;
using Prueba.Web.Models;
using Prueba.Web.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Prueba.Web.Repositories
{
    public class FibonacciNumbersServices : IFibonacciNumbersServices
    {
        private readonly IFibonacciNumbersRepository _fibonacciNumbersRepository;

        public FibonacciNumbersServices(IFibonacciNumbersRepository fibonacciNumbersRepository)
        {
            _fibonacciNumbersRepository = fibonacciNumbersRepository;
        }

        public async Task<bool> AnyNumberAsync(int number)
        {
            return await _fibonacciNumbersRepository.AnyAsync(x => x.Number == number);
        }

        public async Task<bool> AddAsync(FibonacciNumber fibonacciNumber)
        {
            return await _fibonacciNumbersRepository.AddAsync(fibonacciNumber);;
        }
    }
}
