using APIsrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIsrl.Data.Map
{
    public class ServiceMap : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.ServiceDescription).IsRequired().HasMaxLength(200);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.FinalDate).IsRequired();
            builder.Property(x => x.GrossProfit).IsRequired().HasMaxLength(15);
            builder.Property(x => x.NetProfit).IsRequired().HasMaxLength(15);
            builder.Property(x => x.TotalBudget).IsRequired().HasMaxLength(15);
            builder.HasOne(x => x.Client);
        }
    }
}
