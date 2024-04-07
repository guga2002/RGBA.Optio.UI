using Microsoft.AspNetCore.Identity;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using Optio.Core.Repositories;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;

namespace RGBA.Optio.Core.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly OptioDB db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UniteOfWork(OptioDB db, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> role)
        {
            this.db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = role;
        }
        public ICategoryRepo CategoryOfTransactionRepository =>new CategoryOfTransactionRepos(db);

        public IChannel ChanellRepository => new ChannelRepos(db);

        public ILocationRepo LocationRepository => new LocationRepos(db);

        public IMerchantRepo MerchantRepository => new MerchantRepos(db);

        public ITransactionRepo TransactionRepository => new TransactionRepos(db);

        public ITypeOfTransactionRepo TypeOfTransactionRepository => new TypeOfTransactionRepos(db);

        public IUserRepository UserRepository => new UserRepository(db,_userManager,_signInManager,_roleManager);

        public IValuteCourse IValuteCourse => new ValuteRepository(db);

        public async Task CheckAndCommitAsync()
        {
            try
            {
              await  db.SaveChangesAsync();
              await db.Database.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await db.Database.RollbackTransactionAsync();
            }
        }

        public void Dispose()
        {
            db.Dispose();
            _userManager.Dispose();
            _roleManager.Dispose();
        }

    }
}
