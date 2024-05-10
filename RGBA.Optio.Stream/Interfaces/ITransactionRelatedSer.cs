using RGBA.Optio.Stream.DecerializerClasses;

namespace RGBA.Optio.Stream.Interfaces
{
    public interface ITransactionRelatedSer
    {
        Task<bool> fillChannel();
        Task<bool> FillTypeOfTransaction();
        Task InsertCurrencies(List<CurrenciesResponse> cur);
        Task<bool> FillTransactions(int n);
    }
}
