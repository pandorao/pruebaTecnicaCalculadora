using Prueba.Web.Data;
using Prueba.Web.Models;
using Prueba.Web.Repositories.Interfaces;

namespace Prueba.Web.Repositories
{
    public class OperationsRepository : IOperationsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OperationsRepository(ApplicationDbContext dbcontext)
        {
            _applicationDbContext = dbcontext;
        }

        public IEnumerable<Operation> GetAll()
        {
            return _applicationDbContext.Operations;
        }

        public async Task<bool> AddAsync(Operation operation)
        {
            await _applicationDbContext.Operations.AddAsync(operation);
            return await _applicationDbContext.SaveChangesAsync() == 1;
        }
    }
}
