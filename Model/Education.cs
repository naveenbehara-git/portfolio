using MyPortfolio.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Model
{
    public class Education : DatePeriod
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Candidate.candidateId))]
        public int CandidateId { get; set; }
        public string InstitutionName { get; set; }
        public string Specification { get; set; }
        public decimal CGPA { get; set; }
        public string Address { get; set; }

        
    }
}
