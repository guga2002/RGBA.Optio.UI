using Optio.Core.Interfaces;

namespace RGBA.Optio.Core.Interfaces
{
    public interface IUniteOfWork:IDisposable
    {
        ICategoryRepo CategoryOfTransactionRepository { get; }

        IChannelRepo ChanellRepository { get; }

        ILocationRepo LocationRepository { get; }

        IMerchantRepo MerchantRepository { get; }

        ITransactionRepo TransactionRepository { get; }

        ITypeOfTransactionRepo TypeOfTransactionRepository { get; }

        IUserRepository UserRepository { get; }
       
        IValuteCourse IValuteCourse { get; }
        Task CheckAndCommitAsync();
    }
}
