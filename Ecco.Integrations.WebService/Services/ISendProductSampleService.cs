using Ecco.Integrations.WebService.Model.Dto;

namespace Ecco.Integrations.WebService.Services
{
    public interface ISendProductSampleService
    {
        Task SendProduct(Product product);
    }
}
