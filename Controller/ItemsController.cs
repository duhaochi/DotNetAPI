using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

using Catalogs.Repositories;
using Catalogs.Entities;
using Catalogs.Dtos;

namespace Catalog.Controller
{
    // GET /items

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository repository;

        public ItemsController(IInMemItemsRepository repository){
            this.repository = repository;
        }

        // Get /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            // instead of just returning the data storage item, we return a buffer class of ItemDto, so that we can add
            // new values to Item with out breaking the contract with the customer calling the API because they will always get the Dto class
            var items = repository.GetItems().Select(item => item.AsDto()); 
            return items;                     // Select here selects each individual item in the enum and set it as Dto object
        }

        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = repository.GetItem(id);

            if (item is null){
                return NotFound();
            }
            return item.AsDto();
        }

        // Post /items
        
                                                // the createItemDto will be the customer payload/ body of the request, and will be read into 
        [HttpPost]                              // a createItemDto object, so hopefully customer knows what they are doing
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto());
        }
        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto){
            var existingItem = repository.GetItem(id);
            if (existingItem is null){
                return NotFound();
            }
            
            Item updatedItem = existingItem with{
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
            
            var existingItem = repository.GetItem(id);
            if (existingItem is null){
                return NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();
        }
    }
}