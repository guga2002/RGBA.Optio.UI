using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System.Numerics;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ITransactionRelatedService:IAddInfo<ChanellModel>, IAddInfo<CategoryModel>, IAddInfo<TransactionTypeModel>,
        IGetInfo<ChanellModel,BigInteger>, IGetInfo<CategoryModel, BigInteger>, IGetInfo<TransactionTypeModel, BigInteger>,
        IRemoveInfo<ChanellModel, BigInteger>, IRemoveInfo<CategoryModel, BigInteger>, IRemoveInfo<TransactionTypeModel, BigInteger>,
        IUpdateInfo<ChanellModel, BigInteger>, IUpdateInfo<CategoryModel, BigInteger>, IUpdateInfo<TransactionTypeModel, BigInteger>
    {
    }
}
