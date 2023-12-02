using MedicalClinicSystem.Core.Repositories.Implementations;
using MedicalClinicSystem.Core.Repositories.Interfaces;
using MedicalClinicSystem.Core.Serveic;
using MedicalClinicSystem.EF.DataContex;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.EF.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalClinicContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IRepository<Doctor> doctors { get; private set; }
        public IRepository<patient> patients { get; private set; }
        public IRepository<ApplicationUser> users { get; private set; }
        public IRepository<MedicalRecordVM> medicalRecord { get; private set; }
        public IPatientsService patientsService { get; private set; }
        public IAccountService accountService { get; private set; }


        public UnitOfWork(
            MedicalClinicContext context,
            IHttpContextAccessor httpContextAccessor

            )
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
            doctors = new Repository<Doctor>(_context);
            users = new Repository<ApplicationUser>(_context);
            patients = new Repository<patient>(_context);
            medicalRecord = new Repository<MedicalRecordVM>(_context);
            patientsService = new PatientsService(_context);
            accountService = new AccountService(_context, httpContextAccessor);


        }

        public UnitOfWork()
        {
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
