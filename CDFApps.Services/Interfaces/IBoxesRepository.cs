using CDFApps.Domain.dbModels;
using CDFApps.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Services.Interfaces
{
    public interface IBoxesRepository:IBaseRepository<Boxes>
    {
        Task<Boxes> Create(BoxesDto entity);
        Task<Boxes> Update(UpdateBox entity);
        Task<Boxes> GetByReference(string reference);
        Task<bool> Scan(string reference);
        Task<List<Boxes>> SelectReceivedBoxes();
    }
}
