using Optio.Core.Data;
using RGBA.Optio.Core.Interfaces;
using Optio.Core.Entities;
using RGBA.Optio.Stream.Interfaces;
using Faker;
using RGBA.Optio.Stream.DecerializerCLasses;
using RGBA.Optio.Core.Entities;
using Currency = RGBA.Optio.Core.Entities.Currency;
using Microsoft.EntityFrameworkCore;

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
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType="ფილიალი" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "მობილური ინტერნეტ ბანკი" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "ინტერნეტ ბანკი" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "ტერმინალი" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "ნაღდი ანგარიშსწორება" });
            await _uniteOfWork.ChanellRepository.AddAsync(new Channels { ChannelType = "განვადება" });
            return true;
        }
        #endregion

        #region TypeOfTransaction
        public async Task<bool> FillTypeOfTransaction()
        {
            await optioDB.Types.AddAsync(new TypeOfTransaction()
            {
                TransactionName = "შემოსავალი",
                Category = new List<Category>()
                {
                    new Category()
                    {
                        IsActive = true,
                        TransactionCategory="ხელფასი",
                    },
                      new Category()
                    {
                        IsActive = true,
                        TransactionCategory="ბონუსი",
                    },
                        new Category()
                    {
                        IsActive = true,
                        TransactionCategory="დივიდენტი",
                    },
                              new Category()
                    {
                        IsActive = true,
                        TransactionCategory="სხვა შემოსავალი",
                    },
                }
            });
            await optioDB.SaveChangesAsync();
            await optioDB.Types.AddAsync(new TypeOfTransaction()
            {
                TransactionName = "ხარჯი",
                Category = new List<Category>()
                {
                    new Category()
                    {
                        IsActive = true,
                        TransactionCategory="საყოფაცხოვრებო ხარჯი",
                    },
                      new Category()
                    {
                        IsActive = true,
                        TransactionCategory="ტრანსპორტი",
                    },
                        new Category()
                    {
                        IsActive = true,
                        TransactionCategory="კვება და სურსათი",
                    },
                              new Category()
                    {
                        IsActive = true,
                        TransactionCategory="ტრანსპორტი",
                    },
                    new Category()
                    {
                        IsActive = true,
                        TransactionCategory="კომუნალურები",
                    },
                       new Category()
                    {
                        IsActive = true,
                        TransactionCategory="განათლება",
                    },
                }
            });
            await optioDB.SaveChangesAsync();
            await optioDB.Types.AddAsync(new TypeOfTransaction()
            {
                TransactionName = "გადარიცხვა საკუთარ ანგარიშზე",
                Category = new List<Category>()
                {
                    new Category()
                    {
                        IsActive = true,
                        TransactionCategory="შიდა გადარიცხვა",
                    },
                }
            });
            await optioDB.SaveChangesAsync();
            await optioDB.Types.AddAsync(new TypeOfTransaction()
            {
                TransactionName = "სხვასთან გადარიცხვა",
                Category = new List<Category>()
                {
                    new Category()
                    {
                        IsActive = true,
                        TransactionCategory="სხვა ბანკში გადარიცხვა",
                    },
                }
            });
            await optioDB.SaveChangesAsync();
            await optioDB.Types.AddAsync(new TypeOfTransaction()
            {
                TransactionName = "განაღდება",
                Category = new List<Category>()
                {
                    new Category()
                    {
                        IsActive = true,
                        TransactionCategory="თანხის განაღდება",
                    },
                }
            });
            await optioDB.SaveChangesAsync();
            return true;
        }
        #endregion

        #region InsertCurrencies
        public async Task  InsertCurrencies(List<CurrenciesResponse> cur)
        {

            foreach (var currency in cur)
            {
                foreach (var Dgiuri in currency.Currencies)
                {
                    var curenc=await optioDB.Currencies.FirstOrDefaultAsync(io=>io.NameOfValute==Dgiuri.name);
                    if (curenc is  null)
                    {
                        curenc = new Currency()
                        {
                            CurrencyCode = Dgiuri.code,
                            NameOfValute = Dgiuri.name,
                            IsActive = true,
                        };
                    }

                    var valute = new ValuteCourse()
                    {
                        ExchangeRate = (decimal)Dgiuri.rate/Dgiuri.quantity,
                        DateOfValuteCourse = currency.Date,
                        Currency = curenc,
                    };
                    optioDB.ValuteCourses.Add(valute);
                    await optioDB.SaveChangesAsync();
                }
            }
        }
        #endregion
    }
}
