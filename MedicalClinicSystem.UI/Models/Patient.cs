using MedicalClinicSystem.EF.Models;
using System.Collections.Generic;

namespace MedicalClinicSystem.UI.Models
{
    public class PatientModel
    {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Diagnosi { get; set; }
            public int Age { get; set; }
            public char Gender { get; set; }
            // public MedicalRecord MedicalRecords { get; set; }
            public virtual ICollection<MedicalRecord> MedicalRecordsNav { get; set; }



        


    }
}
