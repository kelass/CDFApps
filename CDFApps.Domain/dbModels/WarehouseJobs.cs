using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CDFApps.Domain.dbModels
{
    public class WarehouseJobs
    {
        public Guid Id { get; set; }
        public string JobNumber { get; set; } // номер завоза
        public string ExternalRef { get; set; } // незнаю для чего нужен
        public bool IsReceived { get; set; } // дошел товар или нет
        public string Location { get; set; } // локация куда должно дойти
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; } // Имя пользователя
        

    }
}