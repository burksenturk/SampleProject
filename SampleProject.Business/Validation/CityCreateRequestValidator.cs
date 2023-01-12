using FluentValidation;
using SampleProject.Core.Entity;
using SampleProject.Core.Model.Request.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Validation
{
    public class CityCreateRequestValidator : AbstractValidator<CityCreateRequest>
    {
        public CityCreateRequestValidator()
        {
            RuleFor(create => create.Name).NotEmpty().MinimumLength(2);    //örnek olması amacıyla validasyonlar yapılmıştır!!
        }

    }
}
