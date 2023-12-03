using MedicalClinicSystem.EF.Contex;
using MedicalClinicSystem.EF.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MedicalClinicSystem.Core.Serveic
{
    public class AccountService : IAccountService
    {
        protected MedicalClinicContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountService(MedicalClinicContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public ApplicationUser CheckFromUserLogin(string userName, string password)
        {

            var result = _context.Users.Where(d => d.UserName == userName).FirstOrDefault();

            if (HashPassword($"{password}{result.Salt}") == result.Pass)
            {
                return result;
            }

            return null;

        }

        string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedpassword);

        }


    }
}
