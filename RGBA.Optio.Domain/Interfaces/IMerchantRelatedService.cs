using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface IMerchantRelatedService:IAddInfo<MerchantModel>,IAddInfo<locationModel>,
        IGetInfo<locationModel, BigInteger>,IGetInfo<MerchantModel,BigInteger>,
        IRemoveInfo<locationModel, BigInteger>,IRemoveInfo<MerchantModel, BigInteger>,
        IUpdateInfo<locationModel, BigInteger>,IUpdateInfo<MerchantModel, BigInteger>
    {
        Task<bool> AssignLocationtoMerchant(BigInteger Merchantid, BigInteger Locationid);
    }
}
