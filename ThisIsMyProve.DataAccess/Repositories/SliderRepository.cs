using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMyProve.Core.Entities.HomePageEntities;
using ThisIsMyProve.Core.IRepositories;

namespace ThisIsMyProve.DataAccess.Repositories
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(thisIsMyProveDbContext dbContext) : base(dbContext)
        {
        }
    }
}
