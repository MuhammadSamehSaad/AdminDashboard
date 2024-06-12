using Demo.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Contexts.Configuratinos
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Fluent Apis For Department Domain
            //builder.Property(D => D.Id).UseIdentityColumn(1,1);
            builder.Property(D => D.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

        }
    }
}
