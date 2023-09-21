using System.ComponentModel.DataAnnotations;

namespace TalentToolSystem.Services.UtilityAPI.Models
{
    public class CandidateLog
    {
        //public int LogId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CurrentCompany { get; set; }
        //public IEnumerable<string> SkillSet { get; set; } = null!;
        public int Experience { get; set; }
        public string Location { get; set; }
        public decimal CTC { get; set; }
        public decimal ECTC { get; set; }
        public int NoticePeriod { get; set; }
        public int EmployeeID { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
