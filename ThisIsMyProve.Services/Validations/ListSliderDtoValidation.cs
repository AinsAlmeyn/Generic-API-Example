using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMyProve.Core.DTOs.SliderDtos;

namespace ThisIsMyProve.Services.Validations
{
    public class ListSliderDtoValidation : AbstractValidator<ListSliderDto>
    {
        public ListSliderDtoValidation()
        {
            RuleFor(x => x.Image)
                .NotNull()
                .NotEmpty()
                .WithMessage("Image area can not be empty");
            

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title area can not be empty")
                
                .MaximumLength(75)
                .WithMessage("Title area can accept max 75 letter");


            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Description area can not be empty")

                .MaximumLength(125)
                .WithMessage("Description area can accept max 75 letter");
        }
    }
}
