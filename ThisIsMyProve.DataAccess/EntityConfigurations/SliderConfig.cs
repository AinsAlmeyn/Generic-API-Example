using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThisIsMyProve.Core.Entities.HomePageEntities;

namespace ThisIsMyProve.DataAccess.EntityConfigurations
{
    public class SliderConfig : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(75);

            builder.Property<string>(x => x.Image)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(125);
        }
    }
}
