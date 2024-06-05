using Apteka.Models.Dto;

namespace Apteka.Services.IServices
{
    public interface IPatientService
    {
        public Task<PatientDto> GetById(int patientId);
    }
}
