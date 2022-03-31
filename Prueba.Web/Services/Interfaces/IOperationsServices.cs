using Prueba.Web.Models;

namespace Prueba.Web.Repositories.Interfaces
{
    public interface IOperationsServices
    {
        IEnumerable<Operation> GetAll();
        Task<bool> AddAsync(Operation operation);
    }
}
