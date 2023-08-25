using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;

namespace RichDomain.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class CustomerMapping : BaseMapping, IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer), Schema);
        builder.HasKey(c => c.CustomerId);

        builder.Ignore(c => c.IsValid);

        builder.Property(c => c.CustomerId).HasColumnName("id_customer");

        builder.Property(c => c.FirstName).HasColumnType("varchar(70)").IsUnicode(true)
               .HasColumnName("first_name").IsRequired(true);

        builder.Property(c => c.LastName).HasColumnType("varchar(70)").IsUnicode(true)
               .HasColumnName("last_name").IsRequired(true);

        builder.Property(c => c.CustomerType).HasColumnType("tinyint")
               .HasColumnName("customer_type").IsRequired(true);
        
        builder.Property(c => c.CreateDate).HasColumnType("datetime")
               .HasColumnName("create_date").IsRequired(true);

        builder.OwnsOne(c => c.Phone, phoneBuilder =>
        {
            phoneBuilder.Property(p => p.TelephoneNumber).HasColumnType("Varchar(12)")
                  .HasColumnName("phone_number").IsRequired(false);

            phoneBuilder.Property(p => p.CellPhoneNumber).HasColumnType("Varchar(14)")
                  .HasColumnName("cell_phone").IsRequired(true);
        });

        builder.HasOne(c => c.Email)
               .WithOne()
               .HasForeignKey<Email>(e => e.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
