using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HospitalSystem.Models
{
    public class Clinic 
    {
        [Key]
        public int CID { get; set; }

        [Required]
        public string specilization { get; set; }

        [Range(0, 20)]
        public int NumberOfSlots { get; set; }

        [JsonIgnore]
        public virtual ICollection<Appoinment> Appoinments { get; set; }

    }
}
