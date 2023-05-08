using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IBoxesRepository BoxesRepository { get; }
        IWarehouseJobsRepository WarehouseJobsRepository { get; }
    }
}
