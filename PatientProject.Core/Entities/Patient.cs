using System.ComponentModel.DataAnnotations;

namespace PatientProject.Core.Entities;

public class Patient : BaseEntity
{
    public String Name { get; set; }

    [Required]
    public String Surname { get; set; }

    public String Patronymic { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public bool IsActive { get; set; }

    public int? GenderId { get; set; }

    public Gender Gender { get; set; }
}