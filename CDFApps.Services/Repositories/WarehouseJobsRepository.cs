using CDFApps.Data;
using CDFApps.Domain.dbModels;
using CDFApps.Domain.Dto;
using CDFApps.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Services.Repositories
{
    public class WarehouseJobsRepository : IWarehouseJobsRepository
    {
        private readonly ApplicationDbContext _db;
        public WarehouseJobsRepository(ApplicationDbContext DB)
        {
            _db = DB;
        }
        public async Task<WarehouseJobs> Create(WarehouseJobsDto entity)
        {
            WarehouseJobs whj = new WarehouseJobs
            {
                Id = Guid.NewGuid(),
                Location = entity.Location,
                CreatedBy = entity.CreatedBy,
                CreatedOn = DateTime.Now,
                IsReceived = false,
                JobNumber = "HW" + _db.WarehouseJobs.Count().ToString("D7"),
                ExternalRef = "LRN" + _db.WarehouseJobs.Count().ToString("D7") + "-123-11",
                UpdatedOn = DateTime.Now
            };

           await _db.AddAsync(whj);
           return whj;
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseJobs> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WarehouseJobs>> Select()
        {
            return await _db.WarehouseJobs.ToListAsync();
        }
    }
}
