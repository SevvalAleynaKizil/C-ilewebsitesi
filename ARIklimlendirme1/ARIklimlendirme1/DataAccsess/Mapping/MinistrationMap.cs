using DataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Mapping
{
    public class MinistrationMap : IEntityTypeConfiguration<Ministration>
    {
        public void Configure(EntityTypeBuilder<Ministration> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ministrationname).HasMaxLength(70);
            builder.Property(x => x.Ministrationdescription).HasMaxLength(250);
            builder.Property(x => x.Images).HasMaxLength(100);
            builder.Property(x => x.Ministrationprovided).HasMaxLength(500);
            builder.ToTable("Ministration");
        }
    }
}
