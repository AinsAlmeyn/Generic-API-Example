using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThisIsMyProve.Core.Entities.HomePageEntities;

namespace ThisIsMyProve.DataAccess.SampleValues
{
    public class SliderSampleValues : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData
                (
                    new Slider { Id = 1 , Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." , Image = "null" , Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    new Slider { Id = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Image = "null", Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    new Slider { Id = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Image = "null", Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    new Slider { Id = 4, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Image = "null", Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." }
                );
        }
    }
}
