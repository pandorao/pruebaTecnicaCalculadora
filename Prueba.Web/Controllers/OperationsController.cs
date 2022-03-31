using Microsoft.AspNetCore.Mvc;
using Prueba.Web.Dtos;
using Prueba.Web.Models;
using Prueba.Web.Repositories.Interfaces;

namespace Prueba.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationsServices _operationServices;

        public OperationsController(IOperationsServices operationServices)
        {
            _operationServices = operationServices;
        }

        [HttpGet]
        public IEnumerable<Operation> Get()
        {
            return _operationServices.GetAll();
        }

        [HttpPost]
        public async Task<ServiceResult<string>> AddAsync(OperationDto operationDto)
        {
            return await _operationServices.AddAsync(operationDto.ValueA, operationDto.ValueB);
        }
    }
}