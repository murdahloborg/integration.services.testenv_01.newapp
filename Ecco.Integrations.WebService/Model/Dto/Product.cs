using System.ComponentModel.DataAnnotations;

namespace Ecco.Integrations.WebService.Model.Dto
{
    public sealed class Product
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
