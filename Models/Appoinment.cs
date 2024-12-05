using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models
{
    [PrimaryKey(nameof(CID),nameof(PID),nameof(date))]
    public class Appoinment
    {
       
        public int SlotNumber { get; set; }

        DateTime date { get; set; }

        [ForeignKey("Patient")]
        public int PID { get; set; }

        public virtual Patient Patient { get; set; }

        [ForeignKey ("Clinic")]
        public int CID { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
