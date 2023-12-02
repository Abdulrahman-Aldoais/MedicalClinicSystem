using MedicalClinicSystem.Core.Repositories.Interfaces;
using MedicalClinicSystem.Core.Serveic;
using MedicalClinicSystem.EF.DataContex;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.EF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected MedicalClinicContext _context;

        public Repository(MedicalClinicContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] includes = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var incluse in includes)
                        query = query.Include(incluse);

                return await query.SingleOrDefaultAsync(filter);
            }
            else
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var incluse in includes)
                        query = query.Include(incluse);

                return await query.AsNoTracking().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddMedicalRecordVMAsync(MedicalRecordVM data)
        {
            var newRecord = new MedicalRecord()
            {
                IdPatient = data.IdPatient,
                IdDoctor = data.IdDoctor,
                Diagnosis= data.PatientDiagnosi,
                AgePatient= data.AgePatient,
                TestResults = data.TestResults,
                RescriptionMedications = data.RescriptionMedications,
                Not = data.Not,
                Date = DateTime.Now

            };
            await _context.AddAsync(newRecord);
            await _context.SaveChangesAsync();
        }

      
    }
}
