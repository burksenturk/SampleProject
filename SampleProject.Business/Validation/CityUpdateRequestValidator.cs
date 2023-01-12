using FluentValidation;
using SampleProject.Core.Model.Request.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Validation
{
    public class CityUpdateRequestValidator : AbstractValidator<CityUpdateRequest>
    {
        public CityUpdateRequestValidator()
        {
            RuleFor(update => update.Id).NotEmpty().GreaterThan(0);
            RuleFor(update => update.Name).NotEmpty().MinimumLength(2);
        }
    }
}
