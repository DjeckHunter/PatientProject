namespace PatientProject.Core.DTOs.Patient
{
    public class PatientUpdateRequestDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public Guid GenderId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
