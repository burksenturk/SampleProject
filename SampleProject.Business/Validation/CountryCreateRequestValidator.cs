using FluentValidation;
using SampleProject.Core.Model.Request.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Validation
{
    public class CountryCreateRequestValidator : AbstractValidator<CountryCreateRequest>
    {
        public CountryCreateRequestValidator()
        {
            RuleFor(create => create.Name).NotEmpty().MinimumLength(2);
        }
    }
}
