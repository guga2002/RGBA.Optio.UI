using RGBA.Optio.Core.Interfaces;
using Optio.Core.Entities;
using RGBA.Optio.Stream.Interfaces;

namespace RGBA.Optio.Stream.SeedServices
{
    public class MerchantRelatedSer:IMerchantRelatedSer
    {
        private readonly IUniteOfWork _uniteOfWork;
        public MerchantRelatedSer(IUniteOfWork _uniteOfWork)
        {
            this._uniteOfWork = _uniteOfWork;
        }


        public async Task<bool> FillDataToLocation()
        {
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Tbilisi",IsActive = true});
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Rustavi", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Batumi", IsActive = true });
            await  _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Qobuleti", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Gardabani", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Bakuriani", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Lanchkhuti", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Ureki", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Gori", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Gudauri", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Zugdidi", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Samtredia", IsActive = true });
            await  _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Poti", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Mestia", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Telavi", IsActive = true });
            await _uniteOfWork.LocationRepository.AddAsync(new Location { LocationName = "Sighnaghi", IsActive = true });
            return true;
        }


    }
}
