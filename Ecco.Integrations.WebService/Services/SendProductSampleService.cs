using AutoMapper;
using Ecco.Integrations.WebService.Model.Dto;
using Ecco.Integrations.WebService.Model.Internal;

namespace Ecco.Integrations.WebService.Services
{
    internal sealed class SendProductSampleService : ISendProductSampleService
    {
        private readonly IMapper mapper;

        public SendProductSampleService(IMapper mapper) 
        { 
            this.mapper = mapper;
        }

        public Task SendProduct(Product product)
        {
            var targetProduct = mapper.Map<TargetProduct>(product);
            //TO DO:send targetProduct
            return Task.CompletedTask;
        }
    }
}
