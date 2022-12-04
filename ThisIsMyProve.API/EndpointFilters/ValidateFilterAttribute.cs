using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ThisIsMyProve.API.EndpointFilters.FiltersResponse;
using ThisIsMyProve.Core.DTOs.SliderDtos;

namespace ThisIsMyProve.API.EndpointFilters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(GeneralResponse<ListSliderDto>.Fail(400, errors));
            }
        }
    }
}
