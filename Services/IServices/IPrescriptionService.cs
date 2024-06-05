using Apteka.Models.Dto;

namespace Apteka.Services.IServices
{
    public interface IPrescriptionService
    {
        public Task MakeNewPrescriptionAsync(AddPrescriptionDto inputPresc);
    }
}
