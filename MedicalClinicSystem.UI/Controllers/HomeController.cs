using MedicalClinicSystem.Core.Serveic;
using MedicalClinicSystem.EF.DataContex;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.EF.ViewModels;
using MedicalClinicSystem.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedicalClinicSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(
            ILogger<HomeController> logger, 
             HttpClient httpClient,
             IHttpContextAccessor httpContextAccessor
             )
        {
            _logger = logger;
            //_httpClient = new HttpClient();
            _httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }


        public async Task<ActionResult<IEnumerable<patient>>> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Main/Patients");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<patient> patientInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<patient>>(data);
                return View(patientInfo);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<patient>>> AllPatients()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Main/Patients");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<patient> patientInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<patient>>(data);
                return View(patientInfo);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult AddUser()
        {
             /*if (response.IsSuccessStatusCode)
            {
                return View(dataUser);
            }
            else
            {
                return View("Error");
            }*/
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(string userName, string pass)
        {
            var salt = DateTime.Now.ToString();

            var HashedPW = HashPassword($"{pass}{salt}");
            UserModel dataUser = new UserModel { UserName = userName, Pass = HashedPW, Salt=salt };
            string data = JsonSerializer.Serialize(dataUser);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:5001/api/Main/User", content);
            /*if (response.IsSuccessStatusCode)
            {
                return View(dataUser);
            }
            else
            {
                return View("Error");
            }*/
            return View();
        }


        [HttpGet]
        public IActionResult AddPatient()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(string name, string phone,int age, char gender)
        {

            patient dataUser = new patient { Name = name, Phone = phone, Age=age, Gender=gender };
            string data = JsonSerializer.Serialize(dataUser);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:5001/api/Main/AddPatient", content);
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ViewPatientDetails(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Main/GetPatient/"+id);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                patient patientInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<patient>(data);
                return View(patientInfo);
            }
            else
            {
                return View("Error");
            }
        }

       
        public async Task<IActionResult> WritingPatientReport(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Main/GetPatient/" + id);
            if (response.IsSuccessStatusCode)
            {
                string informationPatient = await response.Content.ReadAsStringAsync();
                patient Patiant = Newtonsoft.Json.JsonConvert.DeserializeObject<patient>(informationPatient);

                var addRepotForPatient = new MedicalRecordVM
                {
                    IdPatient = Patiant.Id,
                    PatientName = Patiant.Name,
                    AgePatient = Patiant.Age,
                    PatientDiagnosi= Patiant.Diagnosi,
                    PatientGender = Patiant.Gender,
                    PatientPhone = Patiant.Phone,
                };

                return View(addRepotForPatient);
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> WritingPatientReport(string testResults, string rescriptionMedications,string not,string diagnosi, MedicalRecordVM medicalRecordVM)
        {
            if (ModelState.IsValid)
            {
                MedicalRecordVM dataUser = new MedicalRecordVM { IdPatient = medicalRecordVM.IdPatient,
                    IdDoctor = httpContextAccessor.HttpContext.Session.GetString("DoctorId"),AgePatient =medicalRecordVM.AgePatient,
                    TestResults = testResults, RescriptionMedications =rescriptionMedications, Not =not, PatientDiagnosi=diagnosi };

                string data = JsonSerializer.Serialize(dataUser);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:5001/api/Main/AddReportPatient", content);
                if (response.IsSuccessStatusCode)
                {
                    


                    return RedirectToAction(nameof(AllPatients));
                }
                return View("Error");

            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> PatientRepotAsPDF(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Main/GetInfrmationReport/" + id);
            if (response.IsSuccessStatusCode)
            {
                string informationPatient = await response.Content.ReadAsStringAsync();
                MedicalRecord Patiant = Newtonsoft.Json.JsonConvert.DeserializeObject<MedicalRecord>(informationPatient);

                if (Patiant == null)
                {

                    return RedirectToAction(nameof(AllPatients));
                }

                var result = new MedicalRecordVM
                {
                    IdPatient = Patiant.IdPatient,
                    IdDoctor = Patiant.IdDoctor,
                    AgePatient = Patiant.AgePatient,
                    PatientDiagnosi = Patiant.Diagnosis,
                    TestResults = Patiant.TestResults,
                    RescriptionMedications = Patiant.RescriptionMedications,
                    Not= Patiant.Not,
                };


                return  new ViewAsPdf("PatientRepotAsPDF", result)
                {
                    PageOrientation = Orientation.Portrait,
                    MinimumFontSize = 25,
                    PageSize = Size.A4,
                    CustomSwitches = " --print-media-type --no-background --footer-line --header-line --page-offset 0 --footer-center [page] --footer-font-size 8 --footer-right \"page [page] from [topage]\"  "
                };
            }
            return NotFound();
        }

     
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<patient>>> PatientSearchByName(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {

                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5001/api/Main/Search/" + searchString);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<patient> filteredResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<patient>>(data);
                   
                   
                    return View("AllPatients", filteredResult);
                }
                else
                {
                    return View("Error");
                }
                
            }
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedpassword);

        }

    }
}
