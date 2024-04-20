using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System.Numerics;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ICurrencyRelatedService:IAddInfo<CurrencyModel>,IAddInfo<ValuteModel>,
        IGetInfo<CurrencyModel, int>,IGetInfo<ValuteModel, BigInteger>,
        IRemoveInfo<CurrencyModel,int>,IRemoveInfo<ValuteModel, BigInteger>,
        IUpdateInfo<CurrencyModel,int>,IUpdateInfo<ValuteModel, BigInteger>
    {

    }
}
