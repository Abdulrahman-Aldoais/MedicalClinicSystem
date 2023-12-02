using MedicalClinicSystem.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicSystem.Core.Serveic
{
    public interface IAccountService
    {
        ApplicationUser CheckFromUserLogin(string userName, string password);
    }
}
