using Catalogs.Dtos;
using Catalogs.Entities;
namespace Catalog{
    public static class Extensions{
                                    // (wrong) I think the this key word is what enable extend this function to be a class function for the Item class
        public static ItemDto AsDto(this Item item){
            return new ItemDto {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}