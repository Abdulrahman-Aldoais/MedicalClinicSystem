using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.EF.Models
{
    public class Doctor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<patient> Patients { get; set; }

    }
}
