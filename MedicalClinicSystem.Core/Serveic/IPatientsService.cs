using MedicalClinicSystem.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.Serveic
{
    public interface IPatientsService
    {
        Task<IEnumerable<patient>> Search(string name);
        Task<MedicalRecord> GetRecordByPatientIdAsync(int id);

    }
}
