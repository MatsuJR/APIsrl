using APIsrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIsrl.Data.Map
{
    public class ClientMap : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Services);
        }
    }
}
