using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Model
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Candidate.candidateId))]
        public int CandidateId { get; set; }
        public string SkillName { get; set; }
        public decimal YearsOfExperience { get; set; }
        public int Proficiency { get; set; }

    }
}
