namespace MarketPlace.Domain.Core.Application.Contract.Services.Log
{
    public interface IErrorLogService
    {
        Task<int> GetViewsCountInThisWeek();
        Task LogError(Dictionary<string, string> properties, int errorCode);
    }
}
