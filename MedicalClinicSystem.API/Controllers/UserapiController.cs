using MedicalClinicSystem.Core.UnitOfWork;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.EF.ViewModels;
using MedicalClinicSystem.UI.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedicalClinicSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserapiController : Controller
    {
      
        private readonly IUnitOfWork unitOfWork;

        public UserapiController(
         
             IUnitOfWork unitOfWork
           
             )
        {
            this.unitOfWork = unitOfWork;

        }


        [HttpGet("Login/{userNmae}/{password}")]
        public ApplicationUser Login(string userNmae,string password)
        {
            var resultCheck = unitOfWork.accountService.CheckFromUserLogin(userNmae, password);

          
            return resultCheck;
        }
    }
}
