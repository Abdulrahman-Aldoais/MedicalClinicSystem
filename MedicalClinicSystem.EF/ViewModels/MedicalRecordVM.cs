using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.EF.ViewModels
{
    public class MedicalRecordVM
    {
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientDiagnosi { get; set; }
        public int AgePatient { get; set; }
        public char PatientGender { get; set; }
        public int IdPatient { get; set; }
        public string IdDoctor { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string TestResults { get; set; }
        public string RescriptionMedications { get; set; }
        public string Not { get; set; }

    }
}
