using APIsrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIsrl.Data.Map
{
    public class MaterialMap : IEntityTypeConfiguration<MaterialModel>
    {
        public void Configure(EntityTypeBuilder<MaterialModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Width);
            builder.Property(x => x.Height);
            builder.Property(x => x.Length);
            builder.Property(x => x.Thickness);

        }
    }
}
