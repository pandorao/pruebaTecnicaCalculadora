namespace Prueba.Web.Models
{
    public class ServiceResult : AbstractServiceResult
    {
        public ServiceResult()
        {
            Errors = new Dictionary<string, string[]>();
        }
    }

    public class ServiceResult<T> : AbstractServiceResult
    {
        public ServiceResult()
        {
            Errors = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Objeto de respuesta
        /// </summary>
        public T ResponseObject { get; set; }
    }

    public abstract class AbstractServiceResult
    {
        public StatusCode StatusCode { get; set; } = StatusCode.Error;

        public Dictionary<string, string[]> Errors { get; set; }

        public bool Succeeded()
        {
            return Errors.Count() == 0 && StatusCode == StatusCode.Succeded;
        }
    }

    public enum StatusCode
    {
        Succeded = 0,
        Warning = 1,
        Error = 2
    }
}
