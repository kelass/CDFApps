using CDFApps.Domain.dbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFApps.Data.Configurations
{
    public class BoxesConfiguration:IEntityTypeConfiguration<Boxes>
    {
        public void Configure(EntityTypeBuilder<Boxes> builder)
        {
            builder.HasData(new Boxes[]
            {
                 
            });
        }
    }
}
