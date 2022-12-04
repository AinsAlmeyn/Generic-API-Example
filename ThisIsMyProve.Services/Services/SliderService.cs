using ThisIsMyProve.Core.Entities.HomePageEntities;
using ThisIsMyProve.Core.IRepositories;
using ThisIsMyProve.Core.IServices;

namespace ThisIsMyProve.Services.Services
{
    public class SliderService : GenericService<Slider>, ISliderService
    {
        public SliderService(IGenericRepository<Slider> repo) : base(repo)
        {
        }
    }
}
