using MedicalClinicSystem.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace MedicalClinicSystem.EF.DataContex
{
    public  class MedicalClinicContext: IdentityDbContext<ApplicationUser>
    {
        public MedicalClinicContext(DbContextOptions<MedicalClinicContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            modelBuilder.Entity<ApplicationUser>().ToTable("User", "myschema");

            var salt = DateTime.Now.ToString();

            var HashedPW = HashPassword($"{"P@ssword1"}{salt}");


            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    //Id = Guid.NewGuid().ToString(),
                    Id = "56508bd7-661c-4f12-907e-e814b101da5d",
                    UserName = "abdulrahman@exe.com",
                    Pass = HashedPW,
                    Salt = salt,
                    PasswordHash = HashedPW,
                }
               );


            modelBuilder.Entity<patient>().HasData(
                new patient
                {
                    Id = 1,
                    Name = "احمد خالد",
                    Age = 23,
                    DateTime = DateTime.Now,
                    Phone = "773453534",


                } );
                

            string HashPassword(string password)
            {
                SHA256 hash = SHA256.Create();

                var passwordBytes = Encoding.Default.GetBytes(password);

                var hashedpassword = hash.ComputeHash(passwordBytes);

                return Convert.ToHexString(hashedpassword);

            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
