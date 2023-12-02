namespace MedicalClinicSystem.UI.Models
{
    public class MedicalRecordModel
    {
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientDiagnosi { get; set; }
        public int PatientAge { get; set; }
        public char PatientGender { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public string TestResults { get; set; }
        public string RescriptionMedications { get; set; }
        public string Not { get; set; }

    }
}
