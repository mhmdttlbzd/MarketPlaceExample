using MarketPlace.Domain.Core.Application.Entities._log;

namespace MarketPlace.Domain.Core.Application.Contract.Services.Log
{
    public interface IErrorLogService
    {
        Task<int> GetErrorsCountInThisWeek();
        Task LogError(Dictionary<string, string> properties, int errorCode);
        Task<IEnumerable<ErrorLog>> GetAll();
        Task<IEnumerable<ErrorLog>> GetByErrorCode(int errorCode);

	}
}
