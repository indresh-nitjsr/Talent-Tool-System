using System.ComponentModel.DataAnnotations;

namespace TalentToolSystem.Services.Search.DTO
{
    public class DemandDTO
    {
        public int? DemandId { get; set; }
        public string DemandName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Account_Name { get; set; }
        public string? Manager { get; set; }
        public int OpenPosition { get; set; } = 0;
        public int? Experience { get; set; }
        public double MaxBudget { get; set; } = 0;
        public int NoticePeriod { get; set; } = 0;
        public string EmployeeType { get; set; } = "";
        public string Status { get; set; } = "";
        public IEnumerable<string> Skills { get; set; } = null!;
        public string Location { get; set; } = "";
    }
}
