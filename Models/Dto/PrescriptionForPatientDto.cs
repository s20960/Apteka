using System.ComponentModel.DataAnnotations;

namespace Apteka.Models.Dto
{
    public class PrescriptionForPatientDto
    {
        public int IdPrescription { get; set; }

        [Required]
        //[Column("Wystawienie")]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DoctorForPrescriptioForPatientDto Doctor { get; set; }

        public List<MedicamentForPrescriptionForPatientDto> Medicaments { get; set; }
    }
}
