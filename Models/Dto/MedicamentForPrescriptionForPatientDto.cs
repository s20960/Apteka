using System.ComponentModel.DataAnnotations;

namespace Apteka.Models.Dto
{
    public class MedicamentForPrescriptionForPatientDto
    {
        public int IdMedicament { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Dose { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        //[Required]
        //[MaxLength(100)]
        //public string Type { get; set; }

        //[Required]
        //[MaxLength(100)]
        //public string Details { get; set; }
    }
}
