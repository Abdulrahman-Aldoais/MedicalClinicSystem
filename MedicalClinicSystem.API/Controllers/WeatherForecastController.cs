using MedicalClinicSystem.EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinicSystem.API.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {


        //private readonly I
        //Service _PatientService;
        //public WeatherForecastController(IPatientService patientService)
        //{
        //    _PatientService = patientService;
        //}


        //[HttpGet]
        //public ActionResult<IEnumerable<patient>> GetAll()
        //{
        //    var patient = _PatientService.GetAll();
        //    return patient.ToList();
        //}

        private readonly ILogger<WeatherForecastController> _logger;
  

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
