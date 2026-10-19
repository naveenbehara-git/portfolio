using MyPortfolio.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Model
{
    public class Candidate
    {
        [Key]
        public int candidateId { get; set; }
        public Guid userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public Gender gender { get; set; }
        public DateTime dob { get; set; }
        public List<Address> address { get; set; } = new List<Address>();
        public string careerObjective { get; set; }
        public string maritalStatus { get; set; }
        public List<WorkExperience> experiences { get; set; } = new List<WorkExperience>();
        public List<Education> educations { get; set; } = new List<Education>();
        public List<Skill> skills { get; set; } = new List<Skill>();
        public List<Language> languages { get; set; } = new List<Language>();
        public string? imagePath { get; set; }
        public string? certifications { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
