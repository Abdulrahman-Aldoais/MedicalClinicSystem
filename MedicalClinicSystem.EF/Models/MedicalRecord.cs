using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.EF.Models
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {
            Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public virtual patient PatientsNav { get; set; }
        public string IdDoctor { get; set; }
        public virtual Doctor DoctorsNav { get; set; }
        public int AgePatient { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public  DateTime Date { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]
        public string TestResults { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]
        public string Diagnosis { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]
        public string RescriptionMedications { get; set; }
        public string Not { get; set; } 
    }
}
