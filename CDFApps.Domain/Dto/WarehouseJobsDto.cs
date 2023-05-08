using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Domain.Dto
{
    public class WarehouseJobsDto
    {
        public Guid Id { get; set; }
        public string JobNumber { get; set; }
        public string ExternalRef { get; set; }
        public bool IsReceived { get; set; }
        public string Location { get; set; }
        [Timestamp]
        public DateTime CreatedOn { get; set; }
        [Timestamp]
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
