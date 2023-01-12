using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Business.Validation;
using SampleProject.Core.Model.Request.Country;
using SampleProject.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CountryCreateRequest countryCreateRequest)
        {
            CountryCreateRequestValidator validator = new CountryCreateRequestValidator();
            var validateResult = validator.Validate(countryCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _countryService.Create(countryCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(CountryUpdateRequest countryUpdateRequest)
        {
            CountryUpdateRequestValidator validator = new CountryUpdateRequestValidator();
            var validateResult = validator.Validate(countryUpdateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _countryService.Update(countryUpdateRequest));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _countryService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _countryService.Get(x => x.Id == Id));
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _countryService.Get(x => x.Name == name));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAllByFilter());
        }
    }
}
