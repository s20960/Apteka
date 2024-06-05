using Apteka.Context;
using Apteka.Models;
using Apteka.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Services
{
    public class PatientService
    {
        private readonly AptekaContext _context;

        public PatientService(AptekaContext context)
        {
            _context = context;
        }

        public async Task<PatientDto> GetById(int patientId)
        {   
            var patient = await _context.Patients
                .Include(x=>x.Prescriptions)
                    .ThenInclude(x=>x.PrescriptionMedicaments)
                        .ThenInclude(x=>x.Medicament)
                .Include(x => x.Prescriptions)
                    .ThenInclude(x=>x.Doctor)
                .FirstOrDefaultAsync(p => p.IdPatient == patientId)
                ?? throw new ArgumentException($"Pacjent o Id {patientId} niestety nie istnieje");

            var response = new PatientDto
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                Prescriptions = (ICollection<Prescription>)patient.Prescriptions
                .OrderBy(x => x.DueDate)
                .Select(pr => new PrescriptionForPatientDto
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Medicaments = pr.PrescriptionMedicaments
                        .Select(pm => new MedicamentForPrescriptionForPatientDto
                        {
                            IdMedicament = pm.Medicament.IdMedicament,
                            Name = pm.Medicament.Name,
                            Dose = pm.Dose,
                            Description = pm.Medicament.Description
                            }).ToList(),
                    Doctor = new DoctorForPrescriptioForPatientDto
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName
                    },
                }).ToList()
            };

            return response;
        }
    }
}
