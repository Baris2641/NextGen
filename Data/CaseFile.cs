using System.ComponentModel.DataAnnotations;

namespace efCoreApp.Data
{
    public class CaseFile
    {
        [Key]
        public int Id { get; set; }
        public string? CaseFileName { get; set; }
        public int LawyerId { get; set; }
        public string? LawyerName { get; set; }
        public string? LawyerSurname { get; set; }
        public string? LawyerFullName
        {
            get
            {
                return this.LawyerName + " " + this.LawyerSurname;
            }
        }
        public int CaseStatusId { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }

    }
}