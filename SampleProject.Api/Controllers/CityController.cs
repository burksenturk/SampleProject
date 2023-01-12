using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Business.Validation;
using SampleProject.Core.Model;
using SampleProject.Core.Model.Request.City;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CityCreateRequest cityCreateRequest)
        {
            CityCreateRequestValidator validator = new CityCreateRequestValidator();
            var validateResult = validator.Validate(cityCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _cityService.Create(cityCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(CityUpdateRequest cityUpdateRequest)
        {
            CityUpdateRequestValidator validator = new CityUpdateRequestValidator();
            var validateResult = validator.Validate(cityUpdateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _cityService.Update(cityUpdateRequest));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _cityService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _cityService.Get(x => x.Id == Id, x => x.Country));
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _cityService.Get(inculudes: x => x.Country,filter:x => x.Name == name ));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityService.GetAllByFilter(inculudes:  x=>x.Country));
        }

    }
}
