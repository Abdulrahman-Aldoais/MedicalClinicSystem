using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.EF.ViewModels
{
    public class PatientVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Diagnosi { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

    }
}
