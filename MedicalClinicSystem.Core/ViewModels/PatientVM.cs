using MedicalClinicSystem.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.ViewModels
{
    public class PatientVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Diagnosi { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public string TestResults { get; set; }
        public string RescriptionMedications { get; set; }
        public string Not { get; set; }


    }
}
