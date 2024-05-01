using Optio.Core.Data;
using RGBA.Optio.Core.Interfaces;
using Optio.Core.Entities;
using RGBA.Optio.Stream.Interfaces;
using Faker;

namespace RGBA.Optio.Stream.SeedServices
{
    public class TransactionRelatedSer:ITransactionRelatedSer
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly OptioDB optioDB;
        private readonly Random rand;
        private readonly Random rand1;
        public TransactionRelatedSer(IUniteOfWork _uniteOfWork, OptioDB optioDB)
        {
            this._uniteOfWork = _uniteOfWork;
            this.optioDB = optioDB;
            rand = new Random();
            rand1 = new Random();
        }

        #region channel
        public async Task<bool> fillChannel()
        {
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType="Piliali" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "Mobiluri banki" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "Internet banki" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "terminali" });
            return true;
        }
        #endregion

        #region TypeOfTransaction
        public async Task<bool> FillTypeOfTransaction()
        {
            await _uniteOfWork.TypeOfTransactionRepository.AddAsync(new TypeOfTransaction { TransactionName = "Shemosavali" });
            await _uniteOfWork.TypeOfTransactionRepository.AddAsync(new TypeOfTransaction { TransactionName = "Xarji" });
            await _uniteOfWork.TypeOfTransactionRepository.AddAsync(new TypeOfTransaction { TransactionName = "Gadaricxva sakutar angarishebs shoris" });
            await _uniteOfWork.TypeOfTransactionRepository.AddAsync(new TypeOfTransaction { TransactionName = "ganaghdeba" });
            return true;
        }
        #endregion
    }
}
