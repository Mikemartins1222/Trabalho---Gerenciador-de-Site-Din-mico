﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Domain.IServices
{
    public  interface IBaseService<T> where T : class
    {

        List<T> FindAll();
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Delete(int id);
    }
}
