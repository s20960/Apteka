using System.ComponentModel.DataAnnotations;

namespace Apteka.Models.Dto
{
    public class AddPrescriptionMedicamentDto
    {
        public int IdPrescriptionMedicament { get; set; }

        [Required]
        public int Dose { get; set; }

        [Required]
        [MaxLength(100)]
        public string Details { get; set; }
    }
}
