using MedicalClinicSystem.Core.Serveic;
using MedicalClinicSystem.EF.Models;
using MedicalClinicSystem.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
       
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> filter, string[] includes = null, bool tracked = true);

        Task<T> AddAsync(T entity);
        Task AddMedicalRecordVMAsync(MedicalRecordVM data);
       

    }
}
    