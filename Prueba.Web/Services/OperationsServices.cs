using Prueba.Web.Data;
using Prueba.Web.Models;
using Prueba.Web.Repositories.Interfaces;

namespace Prueba.Web.Repositories
{
    public class OperationsServices : IOperationsServices
    {
        private readonly IOperationsRepository _operationsRepository;

        public OperationsServices(IOperationsRepository operationsRepository)
        {
            _operationsRepository = operationsRepository;
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operationsRepository.GetAll();
        }

        public async Task<bool> AddAsync(Operation operation)
        {
            return await _operationsRepository.AddAsync(operation);
        }
    }
}
