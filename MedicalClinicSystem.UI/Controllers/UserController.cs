using MedicalClinicSystem.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace MedicalClinicSystem.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserController(
            ILogger<UserController> logger,
             HttpClient httpClient,
             IHttpContextAccessor httpContextAccessor

            )
        {
            _logger = logger;
            _httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {

            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Userapi/Login/" + userName + "/" + password);
            if (response.IsSuccessStatusCode)
            {

                string informationUser = await response.Content.ReadAsStringAsync();
                ApplicationUser User = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationUser>(informationUser);

                if (User != null)
                {

                    httpContextAccessor.HttpContext.Session.SetString("DoctorId", User.Id);

                    return RedirectToAction("AllPatients", "Home");
                }
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View("Error");
            }

        }



    }
}
