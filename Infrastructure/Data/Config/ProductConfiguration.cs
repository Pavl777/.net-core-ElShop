using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(p => p.Id)
                    .IsRequired()
                    .UseIdentityColumn();
            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.Name)
                    .IsRequired(true)
                    .HasMaxLength(50);

            builder.HasOne(x => x.Species)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.SpeciesId).IsRequired();

            builder.HasOne(x => x.Manufacturer)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.ManufacturerId).IsRequired();

            builder.HasOne(x => x.Phone)
                    .WithOne(x => x.PhoneProduct)
                    .HasForeignKey<Product>(x => x.PhoneId);

            builder.HasOne(x => x.Fridge)
                    .WithOne(x => x.FridgeProduct)
                    .HasForeignKey<Product>(x => x.FridgeId);

            builder.HasOne(x => x.Microwave)
                    .WithOne(x => x.MicrowaveProduct)
                    .HasForeignKey<Product>(x => x.MicrowaveId);

             
        }
       
    }
}
