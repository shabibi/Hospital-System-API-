using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Patient
    {
        [Key]
        public int PID { get; set; }

        [Required]
        public string PName { get; set; }

        public string age { get; set; }

        public enum Gender { Male, Female }
        
        [Required]
         public Gender gender { get; set; }

        public virtual ICollection<Appoinment> Appoinments { get; set; }

    }
}
