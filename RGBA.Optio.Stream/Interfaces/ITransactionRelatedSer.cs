namespace RGBA.Optio.Stream.Interfaces
{
    public interface ITransactionRelatedSer
    {
        Task<bool> fillChannel();
        Task<bool> FillTypeOfTransaction();
    }
}
