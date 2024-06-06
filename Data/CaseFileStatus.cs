using System.ComponentModel.DataAnnotations;

namespace efCoreApp.Data
{
    public class CaseFileStatus
    {
        [Key]
        public int CaseStatusId { get; set; }
        public string CaseStatus { get; set;}

    }
}