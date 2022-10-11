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
    public class InteractionsMap : IEntityTypeConfiguration<Interactions>
    {
        public void Configure(EntityTypeBuilder<Interactions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.Surname).HasMaxLength(25);
            builder.Property(x => x.Phone).HasMaxLength(30);
            builder.Property(x => x.Address).HasMaxLength(150);
            builder.Property(x => x.Mail).HasMaxLength(50);
            builder.Property(x => x.Faultdetail).HasMaxLength(500);
            builder.Property(x => x.dateTime).HasMaxLength(150);
            builder.ToTable("Interactions");
        }
    }
}
