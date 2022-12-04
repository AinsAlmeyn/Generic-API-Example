using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThisIsMyProve.Core.DTOs.SliderDtos;
using ThisIsMyProve.Core.Entities.HomePageEntities;
using ThisIsMyProve.Core.IServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace ThisIsMyProve.API.Controllers.AdminControllers.HomePageElements
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderAdminController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISliderService sliderService;
        private readonly ILogger _logger;
        public SliderAdminController(ISliderService sliderService, ILogger<Slider> logger, IMapper mapper)
        {
            this.mapper = mapper;
            this.sliderService = sliderService;
            _logger = logger;
        }

        [HttpGet("GetSlider/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var article = await sliderService.GetObjectByIdAsync(id);
                if (article == null)
                {
                    return NotFound();
                    _logger.LogError($"Article is null.");
                }
                else
                {
                    _logger.LogInformation($"GetById operations for article is successfully occured. Response = {article.Id}");
                    return Ok(article);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Unexcepted error occured", e.Message);
                return BadRequest();
            }
        }

        [HttpPut("UpdateSlider")]
        public IActionResult SliderUptade(UpdateSliderDto UpdateSliderDto)
        {
            try
            {
                if (UpdateSliderDto == null) { _logger.LogWarning($"Update slider is null."); return BadRequest(); }
                else
                {
                    var slider = mapper.Map<Slider>(UpdateSliderDto);
                    sliderService.UpdateObject(slider);
                    _logger.LogInformation($"Slider successfully updated. Article = {slider.Id}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Unexcepted error occured", e.Message);
                return BadRequest();
            }

        }

        [HttpDelete("DeleteSlider/{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            try
            {
                if (id.ToString() == null) { _logger.LogWarning("For GetByIdDelete id is null"); return BadRequest(); }
                else
                {
                    var article = await sliderService.GetObjectByIdAsync(id);
                    sliderService.RemoveObject(article);
                    _logger.LogInformation($"GetByIdDelete article successfully deleted.{article.Title}, {article.Id}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Unexcepted error occured", e.Message);
                return BadRequest();
            }

        }

        [HttpPost("AddSlider")]
        public async Task<IActionResult> SliderAdd(AddSliderDto sliderDto)
        {
            try
            {
                if (sliderDto == null) { _logger.LogWarning($"For AddSlider article is null."); return BadRequest(); }
                else
                {
                    var mappedData = mapper.Map<Slider>(sliderDto);
                    await sliderService.AddObjectAsync(mappedData);
                    _logger.LogInformation($"For AddSlider article is successfully added, Nesne = {sliderDto.Title}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($" Unexcepted error occured. {e.Message}");
                return BadRequest();
            }
        }
    }
}
