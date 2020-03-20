using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
   public class MicrowaveConfiguration : IEntityTypeConfiguration<Microwave>
    {
        public void Configure(EntityTypeBuilder<Microwave> builder)
        {
            builder.ToTable("Microwaves");

            builder.Property(p => p.Id).IsRequired().UseIdentityColumn();
            
        }
    }
}
