using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ITransactionRelatedService:IAddInfo<ChanellModel>, IAddInfo<CategoryModel>, IAddInfo<TransactionTypeModel>,
        IGetInfo<ChanellModel,Guid>, IGetInfo<CategoryModel, Guid>, IGetInfo<TransactionTypeModel, Guid>,
        IRemoveInfo<ChanellModel,Guid>, IRemoveInfo<CategoryModel, Guid>, IRemoveInfo<TransactionTypeModel, Guid>,
        IUpdateInfo<ChanellModel>, IUpdateInfo<CategoryModel>, IUpdateInfo<TransactionTypeModel>
    {
    }
}
