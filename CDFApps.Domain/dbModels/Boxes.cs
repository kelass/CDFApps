using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Domain.dbModels
{
    public class Boxes
    {
        public Guid Id { get; set; }
        public WarehouseJobs WarehouseJobs { get; set; } // внешний ключ ЗАВОЗА
        public string BoxReference { get; set; } // Отображение номера коробки
        public string Condition { get; set; } // состояние
        public DateTime ExpectedOn { get; set; }
        public DateTime? ReceivedOn { get; set; }
        public string ReceivedBy { get; set; } // получатель
        public bool IsScanned { get; set; } // проверка на скан
    }
}
