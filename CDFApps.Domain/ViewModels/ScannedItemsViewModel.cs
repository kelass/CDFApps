using CDFApps.Domain.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Domain.ViewModels
{
    public class ScannedItemsViewModel
    {
       public List<Boxes>? Boxes { get; set; }

       public string? Search { get; set; }
    }
}
