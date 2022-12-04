using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThisIsMyProve.Core.DTOs.SliderDtos;
using ThisIsMyProve.Core.Entities.HomePageEntities;
using ThisIsMyProve.Core.IServices;

namespace ThisIsMyProve.API.PresentationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePresentationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger logger;
        private readonly IGenericService<Slider> service;
        public HomePresentationController(ILogger<Slider> logger, IGenericService<Slider> service, IMapper mapper)
        {
            _mapper = mapper;
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("HomeSliderList")]
        public async Task<IActionResult> ListSlider()
        {
            //You can use logger inside the method if you want
            try
            {
                var sliders = await service.GetAllObject();
                if (!sliders.Any())
                {
                    return NotFound(sliders);
                }
                var slidersDto = _mapper.Map<List<ListSliderDto>>(sliders);
                if (slidersDto.Any())
                {
                    return Ok(slidersDto);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
            return Ok();
        }
    }
}
