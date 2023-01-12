using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using SampleProject.Core.Model.Request.Country;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;

namespace SampleProject.UI.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string countryName)
        {


            using (var client = new HttpClient())
            {
                CountryCreateRequest countryCreateRequest = new CountryCreateRequest();
                countryCreateRequest.Name = countryName;

                StringContent content = new StringContent(JsonSerializer.Serialize(countryCreateRequest), Encoding.UTF8, "application/json");

                //HTTP POST

                var response = await client.PostAsync("http://localhost:5000/api/Country/create", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["IsSuccess"] = true;

                    return View();
                }

                ViewData["IsSuccess"] = false;

                return View();


            }

        }

    }
}
