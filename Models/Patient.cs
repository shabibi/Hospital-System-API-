﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public enum Gender { Male, Female }
namespace HospitalSystem.Models
{

    public class Patient
    {
        [Key]
        [JsonIgnore]
        public int PID { get; set; }

        [Required]
        public string PName { get; set; }

        public int age { get; set; }

    
        
        [Required]
        public Gender gender { get; set; }

        [JsonIgnore]
        public virtual ICollection<Appoinment> Appoinments { get; set; }

    }
}
