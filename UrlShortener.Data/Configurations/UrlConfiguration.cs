using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Data.Models;

namespace UrlShortener.Data.Configurations
{
    internal class UrlConfiguration : IEntityTypeConfiguration<UrlDb>
    {
        public void Configure(EntityTypeBuilder<UrlDb> builder)
        {
            builder.ToTable("Urls").HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.LongUrl).IsRequired();
        }
    }
}