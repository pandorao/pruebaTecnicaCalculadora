using Prueba.Web.Models;

namespace Prueba.Web.Repositories.Interfaces
{
    public interface IOperationsServices
    {
        IEnumerable<Operation> GetAll();
        Task<ServiceResult<string>> AddAsync(int valueA, int valueB);
    }
}
