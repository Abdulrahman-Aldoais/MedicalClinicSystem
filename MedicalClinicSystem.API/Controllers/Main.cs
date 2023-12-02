using MedicalClinicSystem.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MedicalClinicSystem.Core.Serveic;
using System.Threading.Tasks;
using System.Linq;
using MedicalClinicSystem.EF.DataContex;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MedicalClinicSystem.Core.UnitOfWork;
using MedicalClinicSystem.EF.ViewModels;
using System.Reflection;
using System;

namespace MedicalClinicSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Main : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
       
        public Main(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet("Patients")]
        public async Task<ActionResult<IEnumerable<patient>>> GetAllPatients()
        {
            var result = await this.unitOfWork.patients.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("GetPatient/{id}")]
        public async Task<ActionResult<patient>> GetPatientById(int id)
        {
            var patient = await unitOfWork.patients.GetByIdAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }


        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
        {
            var result = await this.unitOfWork.users.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetById(int id)
        {

            var patient = await unitOfWork.doctors.GetByIdAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }
        [HttpGet("User/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserById(int id)
        {

            var patient = await unitOfWork.users.GetByIdAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }



        [HttpPost("User/")]
        public async Task<ActionResult<ApplicationUser>> AddUser(ApplicationUser user)
        {
            var patient = await unitOfWork.users.AddAsync(user);
            return Ok(patient);
        }


        [HttpGet("Patient/{id}")]
        public async Task<ActionResult<patient>> Search(int id)
        {

            var patient = await unitOfWork.patients.FindAsync(
                ids => ids.Id == id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }


        [HttpPost("AddPatient")]
        public async Task<ActionResult<patient>> AddPatient(patient patient)
        {
            await unitOfWork.patients.AddAsync(patient);
            return Ok(patient);
        }


        [HttpPost("AddReportPatient")]
        public async Task<ActionResult<MedicalRecordVM>> AddReportPatient(MedicalRecordVM medicalRecordVM)
        {
            await unitOfWork.medicalRecord.AddMedicalRecordVMAsync(medicalRecordVM);
            return Ok(medicalRecordVM);
        }


        [HttpGet("GetInfrmationReport/{id}")]
        public async Task<ActionResult<MedicalRecord>> GetInfrmationReport(int id)
        {
            var patient = await unitOfWork.patientsService.GetRecordByPatientIdAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }



        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<patient>>> Search(string name)
        {
            try
            {
                var result = await unitOfWork.patientsService.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "خطأ في استرجاع البيانات من قاعدة البيانات");
            }
        }


    }
}
