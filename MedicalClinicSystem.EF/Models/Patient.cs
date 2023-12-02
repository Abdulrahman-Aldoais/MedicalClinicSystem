using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.EF.Models
{
    public class patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Diagnosi { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public DateTime DateTime { get; set; }= DateTime.Now;
        // public MedicalRecord MedicalRecords { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecordsNav { get; set; }
        public virtual ICollection<Doctor> DoctorsNav { get; set; }



    }
}
