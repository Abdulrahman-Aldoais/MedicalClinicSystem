using MedicalClinicSystem.Core.UnitOfWork;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.EF.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;


namespace MedicalClinicSystem.UI.Controllers
{
    public class UserController : Controller
    {
       
        private readonly ILogger<UserController> _logger;
        private readonly HttpClient _httpClient;
        //private readonly HttpContext httpContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserController(
            ILogger<UserController> logger,
             HttpClient httpClient,
             //HttpContext httpContext,
             IHttpContextAccessor httpContextAccessor

            )
        {
            _logger = logger;
            _httpClient = httpClient;
            //this.httpContext = httpContext;
            this.httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
            //this.signInManager = signInManager;
            //this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

     

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
          
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Userapi/Login/"+userName+"/"+password);
            if (response.IsSuccessStatusCode)
            {

                string informationUser = await response.Content.ReadAsStringAsync();
                ApplicationUser User = Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationUser>(informationUser);

                if (User !=null) { 
                
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
