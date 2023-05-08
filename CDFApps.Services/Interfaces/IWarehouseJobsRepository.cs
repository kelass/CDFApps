using CDFApps.Domain.dbModels;
using CDFApps.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Services.Interfaces
{
    public interface IWarehouseJobsRepository:IBaseRepository<WarehouseJobs>
    {
        Task<WarehouseJobs> Create(WarehouseJobsDto entity);
    }
}
