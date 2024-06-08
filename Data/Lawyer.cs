using System.ComponentModel.DataAnnotations;

namespace efCoreApp.Data
{
    public class Lawyer
    {
        [Key]
        public int LawyerId { get; set; }
        public string LawyerName { get; set;}
        public string? LawyerStatus  { get; set; }
    }
}