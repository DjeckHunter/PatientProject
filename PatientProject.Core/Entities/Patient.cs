using System.ComponentModel.DataAnnotations;

namespace PatientProject.Core.Entities;

public class Patient : BaseEntity
{
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    public string FullName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public bool IsActive { get; set; }

    public Guid? GenderId { get; set; }

    public Gender Gender { get; set; }
}