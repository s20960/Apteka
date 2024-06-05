using Apteka.Context;
using Apteka.Models;
using Apteka.Models.Dto;
using Apteka.Services.IServices;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly AptekaContext _context;

        public PrescriptionService(AptekaContext context)
        {
            _context = context;
        }

        public async Task MakeNewPrescriptionAsync(AddPrescriptionDto inputPresc)
        {
            if (inputPresc.Medicaments.Count > 10)
                throw new ArgumentException("W recepcie może być maksymalnie 10 leków");

            if (inputPresc.Date > inputPresc.DueDate)
                throw new ArgumentException("Data wystawienia nie może być późniejsza niż data przydatności do użycia");

            var patientExists = await _context.Patients
                .Where(x => x.IdPatient == inputPresc.Patient.IdPatient)
                .FirstOrDefaultAsync();

            if (patientExists == null) { 
                var patient = new Patient
                {
                    FirstName = inputPresc.Patient.FirstName,
                    LastName = inputPresc.Patient.LastName,
                    Birthdate = inputPresc.Patient.Birthdate
                };
                _context.Patients.Add(patient);
            }

            var prescription = new Prescription
            {
                Date = inputPresc.Date,
                DueDate = inputPresc.DueDate,
                Patient = patientExists,
                PrescriptionMedicaments = new List<PrescriptionMedicament>()
            };

            foreach(var med in  inputPresc.Medicaments) 
            {
                var medicament = await _context.Medicamens
                    .FirstOrDefaultAsync(x=>x.IdMedicament==med.IdPrescriptionMedicament)
                    ??throw new ArgumentException($"Lek z Id: {med.IdPrescriptionMedicament} nie istnieje");

                prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
                {
                    Medicament = medicament,
                    Dose = med.Dose,
                    Details = med.Details
                });
            }

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

        }
    }
}
