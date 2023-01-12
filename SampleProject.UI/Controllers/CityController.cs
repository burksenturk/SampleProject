using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleProject.Core.Entity;
using SampleProject.Core.Model;
using SampleProject.Core.Model.Request.City;
using SampleProject.Core.Model.Request.Country;
using SampleProject.UI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.UI.Controllers
{
    public class CityController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync("http://localhost:5000/api/Country/getall");

                var responseModel = await response.Content.ReadAsStringAsync();


                var convertModel = JsonConvert.DeserializeObject<BaseResponse<List<CountryModel>>>(responseModel);



                return View(convertModel.Data);


            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cityName,int selectedCountry)
        {
            using (var client = new HttpClient())
            {
                CityCreateRequest cityCreateRequest = new CityCreateRequest();
                cityCreateRequest.Name = cityName;
                cityCreateRequest.CountryId = selectedCountry;

                StringContent content = new StringContent(JsonConvert.SerializeObject(cityCreateRequest), Encoding.UTF8, "application/json");

                //HTTP POST

                var response = await client.PostAsync("http://localhost:5000/api/City/create", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["IsSuccess"] = true;

                    return RedirectToAction("Index");
                }

                TempData["IsSuccess"] = false;

                return RedirectToAction("Index");


            }


        }

        public async Task<IActionResult> List()
        {
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync("http://localhost:5000/api/City/getall");

                var responseModel = await response.Content.ReadAsStringAsync();


                var convertModel = JsonConvert.DeserializeObject<BaseResponse<List<CityModel>>>(responseModel);



                return View(convertModel.Data);


            }


            return View();
        }

        public async Task<IActionResult> Update(int cityId)
        {
            using (var client = new HttpClient())
            {

                var response = await client.GetAsync("http://localhost:5000/api/Country/getall");

                var responseModel = await response.Content.ReadAsStringAsync();


                var convertModel = JsonConvert.DeserializeObject<BaseResponse<List<CountryModel>>>(responseModel);


                var responseCity = await client.GetAsync("http://localhost:5000/api/City/getbyid?Id="+cityId);

                var responseCityModel = await responseCity.Content.ReadAsStringAsync();


                var responseCityConvertModel = JsonConvert.DeserializeObject<BaseResponse<City>>(responseCityModel);

                CityUpdateModel cityUpdateModel = new CityUpdateModel();    

                cityUpdateModel.City= responseCityConvertModel.Data;
                cityUpdateModel.Countries = convertModel.Data;
                return View(cityUpdateModel);


            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(City city)
        {
            using (var client = new HttpClient())
            {
                CityUpdateRequest cityUpdateRequest = new CityUpdateRequest();
                cityUpdateRequest.Name =city.Name ;
                cityUpdateRequest.CountryId = city.CountryId;
                cityUpdateRequest.Id = city.Id;

                StringContent content = new StringContent(JsonConvert.SerializeObject(cityUpdateRequest), Encoding.UTF8, "application/json");

                //HTTP POST

                var response = await client.PutAsync("http://localhost:5000/api/City/update", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["IsSuccess"] = true;

                    return RedirectToAction("Update",new { cityId=city.Id });
                }

                TempData["IsSuccess"] = false;

                return RedirectToAction("Update", new { cityId = city.Id });


            }


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int cityId)
        {
            using (var client = new HttpClient())
            {

                //HTTP POST

                var response = await client.GetAsync("http://localhost:5000/api/City/delete?Id="+cityId);


                return RedirectToAction("List");


            }


        }

    }
}
