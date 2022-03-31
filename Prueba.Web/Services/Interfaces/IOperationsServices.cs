using Prueba.Web.Dtos;
using Prueba.Web.Models;

namespace Prueba.Web.Repositories.Interfaces
{
    public interface IOperationsServices
    {
        IEnumerable<Operation> GetAll();
        Task<ServiceResult<OperationResponseDto>> AddAsync(long valueA, long valueB);
    }
}
