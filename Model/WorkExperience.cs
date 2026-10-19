using MyPortfolio.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class WorkExperience : DatePeriod
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Candidate.candidateId))]
        public int CandidateId { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public decimal CTC { get; set; }
    }
}
