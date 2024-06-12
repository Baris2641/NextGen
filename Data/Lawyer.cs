using System.ComponentModel.DataAnnotations;

namespace efCoreApp.Data
{
    public class Lawyer
    {
        [Key]
        public int LawyerId { get; set; }
        public string? LawyerName { get; set;}
        public string? LawyerSurname { get; set; }
        
        public string? LawyerFullName{
             get
        {
            return this.LawyerName + " " + this.LawyerSurname;
        } 
        }
        public string? LawyerStatus  { get; set; }
        
    }
}