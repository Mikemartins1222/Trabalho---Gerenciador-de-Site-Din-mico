using SolutionDynamicPage.Infra.Data.Context;
using SolutionDynamicPage.Infra.Domain.Entities;
using SolutionDynamicPage.Infra.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        private readonly SQLServerContext _context;

        public UserRepository(SQLServerContext context) : base(context)
        {
            this._context = context;
        }
    }


}
