using CDFApps.Domain.dbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Domain.Dto
{
    public class BoxesDto
    {
        public Guid Id { get; set; }
        public Guid WarehouseJobsId { get; set; }
        public string BoxReference { get; set; }
        public string Condition { get; set; }

        [Timestamp]
        public DateTime ExpectedOn { get; set; }
        [Timestamp]
        public DateTime ReceivedOn { get; set; }
        public string ReceivedBy { get; set; }
    }
}
