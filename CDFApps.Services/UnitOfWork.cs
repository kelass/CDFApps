using CDFApps.Data;
using CDFApps.Services.Interfaces;
using CDFApps.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Services
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private BoxesRepository _boxesRepository;
        private WarehouseJobsRepository _warehouseJobsRepository;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
        public IWarehouseJobsRepository WarehouseJobsRepository
        {
            get
            {
                return _warehouseJobsRepository = _warehouseJobsRepository ?? new WarehouseJobsRepository(_db);
            }
        }
        public IBoxesRepository Boxes
        {
            get
            {
                return _boxesRepository = _boxesRepository ?? new BoxesRepository(_db);
            }
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
