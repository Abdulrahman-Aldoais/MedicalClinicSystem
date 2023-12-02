using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.EF.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {

            //var hasher = new PasswordHasher<ApplicationUser>();
            //Pass = hasher.HashPassword(null, Pass);

        }

        public string Pass { get; set; }
        public string Salt { get; set; }
    }
}
