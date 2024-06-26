﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apteka.Models
{
    //[Table("Recepta")]
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }

        [Required]
        //[Column("Wystawienie")]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }

        [ForeignKey(nameof(IdDoctor))]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(IdPatient))]
        public virtual Patient Patient { get; set; }

        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}
