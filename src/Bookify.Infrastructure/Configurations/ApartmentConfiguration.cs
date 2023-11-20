using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Infrastructure.Configurations;
internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("apartments");
        builder.HasKey(apartment => apartment.Id);
        builder.OwnsOne(apartment => apartment.Address);
        builder.Property(apartment => apartment.Name)
            .HasMaxLength(255)
            .HasConversion(name => name.Value, value => new Name(value));
        builder.Property(apartment => apartment.Description)
            .HasMaxLength(255)
            .HasConversion(descr => descr.Value, value => new Description(value));
        builder.OwnsOne(apartment => apartment.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
        builder.OwnsOne(apartment => apartment.CleaningFee, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}

