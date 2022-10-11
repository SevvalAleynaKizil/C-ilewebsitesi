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
    public class CampaingsMap : IEntityTypeConfiguration<Campaings>
    {
        public void Configure(EntityTypeBuilder<Campaings> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Campaignname).HasMaxLength(250);
            builder.Property(x => x.Campaigndetail).HasMaxLength(500);
            builder.ToTable("Campaings");
        }
    }
}
