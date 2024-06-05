using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apteka.Models
{
    public class PrescriptionMedicament
    {
        [Key]
        public int IdPrescriptionMedicament { get; set; }

        [Required]
        public int Dose { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; }

        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }

        [ForeignKey(nameof(IdMedicament))]
        public virtual Medicament Medicament { get; set; }

        [ForeignKey(nameof(IdPrescription))]
        public virtual Prescription Prescription { get; set; }
    }
}
