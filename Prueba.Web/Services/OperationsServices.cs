using Prueba.Web.Data;
using Prueba.Web.Dtos;
using Prueba.Web.Models;
using Prueba.Web.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Web.Repositories
{
    public class OperationsServices : IOperationsServices
    {
        private readonly IOperationsRepository _operationsRepository;
        private readonly IFibonacciNumbersServices _fibonacciNumbersServices;

        public OperationsServices(IOperationsRepository operationsRepository, IFibonacciNumbersServices fibonacciNumbersServices)
        {
            _operationsRepository = operationsRepository;
            _fibonacciNumbersServices = fibonacciNumbersServices;
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operationsRepository.GetAll();
        }

        public async Task<ServiceResult<OperationResponseDto>> AddAsync(int valueA, int valueB)
        {
            var validationResults = new List<ValidationResult>();
            var operation = new Operation() { ValueA = valueA, ValueB = valueB, Result = valueA + valueB };

            var result = new ServiceResult<OperationResponseDto>();
            if (!IsValid(operation, validationResults))
            {
                result.StatusCode = StatusCode.Warning;
                AddErrors(result, validationResults);
                return result;
            }
            
            var succeded = await _operationsRepository.AddAsync(operation);
            if (!succeded)
            {
                result.StatusCode = StatusCode.Error;
                validationResults.Add(new ValidationResult("No se pudo guardar correctamente la operacion"));
                AddErrors(result, validationResults);
                return result;
            }

            result.StatusCode = StatusCode.Succeded;
            result.ResponseObject = new OperationResponseDto()
            {
                ResultOperation = operation.Result,
                FibonacciMessage = (await _fibonacciNumbersServices.AnyNumberAsync(operation.Result)) ? "Si esta en la serie fibonacci" : "No esta en la serie fibonacci"
            };
            return result;
        }

        #region Helpers
        private bool IsValid(Operation operation, List<ValidationResult> validationResults) 
        {
            var context = new ValidationContext(operation, serviceProvider: null, items: null);
            return Validator.TryValidateObject(operation, context, validationResults, true);
        }

        private void AddErrors(AbstractServiceResult serviceResult, List<ValidationResult> validationResults)
        {
            var errors = new List<string>();

            foreach (var item in validationResults)
            {
                errors.Add(item.ErrorMessage);
            }

            serviceResult.Errors.Add("", errors.ToArray());
        }
        #endregion

    }
}
