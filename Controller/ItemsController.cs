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
        public ActionResult<ItemDto> getItem(Guid id){
            var item = repository.GetItem(id);

            if (item is null){
                return NotFound();
            }
            return item.AsDto();
         
        }
    }
}