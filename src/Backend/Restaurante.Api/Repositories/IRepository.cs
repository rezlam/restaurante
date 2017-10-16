using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Restaurante.Api.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> List();

        Task<int> Create(T model);

        Task<T> Find(int id);

        Task<List<T>> Find(string name);

        Task<bool> Update(T model);

        Task<bool> Delete(int id);
    }
}