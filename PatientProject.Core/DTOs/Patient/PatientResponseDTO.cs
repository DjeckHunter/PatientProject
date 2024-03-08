namespace PatientProject.Core.DTOs.Patient
{
    public class PatientResponseDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
