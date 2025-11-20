using MyPortfolio.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class WorkExperience : DatePeriod
    {
        public string EnterpriseName { get; set; }
        public string Role { get; set; }
        public string SkillsUsed { get; set; }
        public decimal PackageinLPA { get; set; }
        public string JobDescription { get; set; }
    }
}
