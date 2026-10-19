using MyPortfolio.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Candidate.candidateId))]
        public int CandidateId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public AddressType AddressType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
    }
}
