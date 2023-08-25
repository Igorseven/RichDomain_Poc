using RichDomain.API.Business.Domain.Entities;
using RichDomain.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RichDomain.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class EmailMapping : BaseMapping, IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable(nameof(Email), Schema);
        builder.HasKey(e => e.EmailId);

        builder.Ignore(c => c.IsValid);

        builder.Property(e => e.EmailId).HasColumnName("id_email");

        builder.Property(e => e.CustomerId).HasColumnName("customer_id");

        builder.Property(e => e.EmailAddress).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("email").IsRequired(true);

        builder.Property(c => c.CreateDate).HasColumnType("datetime")
               .HasColumnName("create_date").IsRequired(true);

    }
}
