using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface IMerchantRelatedService:IAddInfo<MerchantModel>,IAddInfo<locationModel>,
        IGetInfo<locationModel,Guid>,IGetInfo<MerchantModel,Guid>,
        IRemoveInfo<locationModel,Guid>,IRemoveInfo<MerchantModel,Guid>,
        IUpdateInfo<locationModel>,IUpdateInfo<MerchantModel>
    {

    }
}
