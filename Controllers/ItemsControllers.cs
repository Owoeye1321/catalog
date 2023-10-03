using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Models;
using Catalog.Dtos;

namespace Catalog.Controllers
{
  //this brings a bunch of additional default behaviour for your controller 
  [ApiController]
  //adding a route
  //[Route("[controller]")] //this would make the route inherit the controller name e.g GET /items
  [Route("items")]
  public class ItemController : ControllerBase
  {

    private readonly ItemRepositoryInterface repository;
    public ItemController(ItemRepositoryInterface repository)
    {
      this.repository = repository;
    }
    //define the method type here
    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
      var items = repository.GetItems().Select(item => item.parseDto());
      return items;
    }

    // /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
      var item = repository.GetItem(id);
      if (item == null)
      {
        return NotFound();
      }
      return item.parseDto();
    }
    //POST /items
    [HttpPost]

    public ActionResult<ItemDto> CreateItem(CreateItemDtos itemDto)
    {
      Item item = new()
      {
        Id = Guid.NewGuid(),
        Name = itemDto.Name,
        Price = itemDto.Price,
        CreatedDate = DateTimeOffset.UtcNow
      };
      repository.CreateItem(item);
      return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.parseDto());
    }
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDtos itemDto)
    {
      var existingItem = repository.GetItem(id);
      if (existingItem is null) return NotFound();
      Item updatedItem = existingItem with
      {
        Name = itemDto.Name,
        Price = itemDto.Price
      };
      repository.UpdateItem(updatedItem);
      return NoContent();
    }
  }
}