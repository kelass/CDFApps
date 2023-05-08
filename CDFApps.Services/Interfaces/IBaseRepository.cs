using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Services.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> Select();
        Task<bool> Delete(Guid Id);
        Task<T> GetById(Guid Id);

    }
}
