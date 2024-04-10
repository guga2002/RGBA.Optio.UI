using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ICurrencyRelatedService:IAddInfo<CurrencyModel>,IAddInfo<ValuteModel>,
        IGetInfo<CurrencyModel, int>,IGetInfo<ValuteModel, Guid>,
        IRemoveInfo<CurrencyModel,int>,IRemoveInfo<ValuteModel, Guid>,
        IUpdateInfo<CurrencyModel>,IUpdateInfo<ValuteModel>
    {

    }
}
