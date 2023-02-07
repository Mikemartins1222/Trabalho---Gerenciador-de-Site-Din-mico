using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Domain.IRepositories
{
    public  interface IBaseRepository<T> where T : class
    {

        Task<int> Delete(T entity);
        IQueryable<T> FindAll();
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Update(T entity);
        Task<int> ExecuteCommand(string sqlCommand);
       
    }
}
