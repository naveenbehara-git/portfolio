using MyPortfolio.Model.Common;

namespace MyPortfolio.Model
{
    public class Education : DatePeriod
    {
        public string InstitutionName { get; set; }
        public string Specification { get; set; }
        public decimal CGPA { get; set; }
        public string Address { get; set; }

        
    }
}
