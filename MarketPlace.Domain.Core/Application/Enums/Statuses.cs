namespace MarketPlace.Domain.Core.Application.Enums;

public enum OrderStatus
{
    Active = 1,
    AwaitPayment = 2,
    Bought = 3,
    Deleted = 4,
}

public enum GeneralStatus
{
    AwaitConfirmation = 1,
    Confirmed = 2,
    Failed = 3,
}