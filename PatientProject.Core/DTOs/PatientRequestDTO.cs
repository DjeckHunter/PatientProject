namespace PatientProject.Core.DTOs
{
    public class PatientRequestDTO
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public List<String> AddtionalNames { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
