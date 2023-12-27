using Ecco.Integrations.WebService.Model.Dto;
using Ecco.Integrations.WebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecco.Integrations.WebService.Controllers
{
    [ApiController]
    [Route("api/sample/product")]
    public class ReceiveProductSampleController : ControllerBase
    {
        private readonly ISendProductSampleService sampleService;

        public ReceiveProductSampleController(ISendProductSampleService sampleService) 
        {
            this.sampleService = sampleService;
        }

        [HttpPost]
        public async Task ImportProduct(Product product)
        { 
            await sampleService.SendProduct(product);
        }
    }
}
