using System.ComponentModel.DataAnnotations;

namespace Apteka.Models.Dto
{
    public class AddPrescriptionDto
    {
        public AddPatientDto Patient { get; set; }
        public List<AddPrescriptionMedicamentDto> Medicaments { get; set; }

        [Required]
        //[Column("Wystawienie")]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
