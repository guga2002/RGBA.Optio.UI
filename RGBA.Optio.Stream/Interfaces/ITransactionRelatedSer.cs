using RGBA.Optio.Stream.DecerializerCLasses;

namespace RGBA.Optio.Stream.Interfaces
{
    public interface ITransactionRelatedSer
    {
        Task<bool> fillChannel();
        Task<bool> FillTypeOfTransaction();
        Task InsertCurrencies(List<CurrenciesResponse> cur);
    }
}
