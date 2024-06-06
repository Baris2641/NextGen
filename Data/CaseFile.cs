using System.ComponentModel.DataAnnotations;

namespace efCoreApp.Data
{
    public class CaseFile
    {
        [Key]
        public int Id { get; set; }
        public string CaseFileName { get; set; }
        public int CaseStatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}