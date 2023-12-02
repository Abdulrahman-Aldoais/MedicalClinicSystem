using MedicalClinicSystem.Core.Repositories.Interfaces;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.Core.Serveic;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalClinicSystem.EF.ViewModels;

namespace MedicalClinicSystem.Core.UnitOfWork
{
     public interface IUnitOfWork : IDisposable
    {
        IRepository<Doctor> doctors { get; }
        IRepository<patient> patients { get; }
        IRepository<ApplicationUser> users { get; }
        IRepository<MedicalRecordVM> medicalRecord { get; }
        IPatientsService patientsService { get; }
        IAccountService accountService { get; }
        //public UserManager<User> userManager { get; }
        //public SignInManager<User> signInManager { get; }



        int Complete();
    }
}
