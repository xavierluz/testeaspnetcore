using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Infra.Data.Configuration
{
    public class PersonPhoneConfiguration : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.Ignore(b => b.DomainEvents );

            builder.ToTable("PersonPhone").HasKey(t => new { t.BusinessEntityID,t.PhoneNumber } );

            builder.Property(t => t.BusinessEntityID).HasColumnName("BusinessEntityID").IsRequired(true).ForSqliteHasSrid(1);
            builder.Property(t => t.PhoneNumberTypeID).HasColumnName("PhoneNumberTypeID").IsRequired(true);
            builder.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber").IsRequired(true);

           

            builder.HasData(new PersonPhone { BusinessEntityID = 1, PhoneNumber = "(19)99999-2883", PhoneNumberTypeID = 1 });
            builder.HasData(new PersonPhone { BusinessEntityID = 1, PhoneNumber = "(19)99999-4021", PhoneNumberTypeID = 2 });
        }
    }
}
