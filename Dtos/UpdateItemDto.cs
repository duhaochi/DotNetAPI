using System.ComponentModel.DataAnnotations;

namespace Catalogs.Dtos
{
    public record UpdateItemDto{

        [Required]
        public string Name {get; init; }
        // how can we make Price default to $0
        [Range(1,1000)]
        public decimal Price {get; init; }
    }
    
}