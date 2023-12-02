using MedicalClinicSystem.EF.DataContex;
using MedicalClinicSystem.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.Serveic
{
    public class PatientsService : IPatientsService
    {


        protected MedicalClinicContext _context;

        public PatientsService(MedicalClinicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<patient>> Search(string name)
        {
            IQueryable<patient> query = _context.Patients;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
           
            return await query.ToListAsync();
        }

        public Task<MedicalRecord> GetRecordByPatientIdAsync(int id)
        {
            var result = _context.MedicalRecords.Where(p => p.IdPatient == id).FirstOrDefaultAsync();
            return result;
        }


    }
}
