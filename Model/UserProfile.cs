using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Model
{
    public class UserProfile
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Gender { get; set; }

        public decimal YearsOfExperience { get; set; }
        public string CareerGoal { get; set; }

        public List<WorkExperience> Experience { get; set; }
        public List<Education> Education { get; set; }
        public List<Skill> Skills { get; set; }
        public string CurrentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string? ImagePath { get; set; }
        public string PermanentAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Languages { get; set; }
        public List<string> Certifications { get; set; } = new();

    }
}
