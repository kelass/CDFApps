using CDFApps.Data;
using CDFApps.Domain.dbModels;
using CDFApps.Domain.Dto;
using CDFApps.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CDFApps.Services.Repositories
{
    public class BoxesRepository : IBoxesRepository
    {
        private readonly ApplicationDbContext _db;
        public BoxesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Boxes> Create(BoxesDto entity)
        {
            WarehouseJobs? warehouse = await _db.WarehouseJobs.FirstOrDefaultAsync(w => w.Id == entity.WarehouseJobsId);
            Boxes box = new Boxes
            {
                Id = Guid.NewGuid(),
                BoxReference = "BN-" + _db.Boxes.Count().ToString("D4"),
                WarehouseJobs = warehouse,
                Condition = "good",
                ExpectedOn = entity.ExpectedOn,
                ReceivedBy = entity.ReceivedBy,
                ReceivedOn = null,
                IsScanned = false
            };

            await _db.AddAsync(box);
            return box;
        }

        public async Task<bool> Delete(Guid Id)
        {
            Boxes box = await _db.Boxes.FirstOrDefaultAsync(b => b.Id == Id);
            if (box != null)
            {
                _db.Remove(box);
                return true;
            }
            return false;
        }

        public async Task<Boxes> GetById(Guid Id)
        {
            Boxes? box = await _db.Boxes.Include(b=>b.WarehouseJobs).FirstOrDefaultAsync(b => b.Id == Id);

            return box;
        }

        public Task<Boxes> GetByReference(string reference)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Scan(string reference)
        {
            Boxes box = await _db.Boxes.Include(b => b.WarehouseJobs).FirstOrDefaultAsync(b => b.BoxReference == reference);
            if (box != null)
            {
                box.IsScanned = true;
                box.ReceivedOn = DateTime.Now;
                _db.Update(box);
                _db.SaveChanges();

                //Received status and update
                List<Boxes> warehouseBoxes = await _db.Boxes.Where(b => b.WarehouseJobs.Id == box.WarehouseJobs.Id).ToListAsync();
                List<Boxes> warehouseBoxesIsScanned = await _db.Boxes.Where(b => b.WarehouseJobs.Id == box.WarehouseJobs.Id && b.IsScanned == true).ToListAsync();
                if (warehouseBoxes.Count == warehouseBoxesIsScanned.Count)
                {
                    box.WarehouseJobs.IsReceived = true;
                    box.WarehouseJobs.UpdatedOn = DateTime.Now;
                    _db.Update(box);
                    
                }
            return true;
            }

            return false;
        }

        public async Task<List<Boxes>> Select()
        {
            return await _db.Boxes.Where(b => b.IsScanned == true).Include(b => b.WarehouseJobs).ToListAsync();
        }

        public async Task<List<Boxes>> SelectReceivedBoxes()
        {
            return await _db.Boxes.Where(b => b.IsScanned == true).Include(b => b.WarehouseJobs).ToListAsync();
        }

        public async Task<Boxes> Update(UpdateBox entity)
        {
            var box = await _db.Boxes.FirstOrDefaultAsync(b=>b.Id == entity.Id);

            if (box != null)
            {
                box.Condition = entity.Condition;
                _db.Update(box);
            }
            return box;
        }
    }
}