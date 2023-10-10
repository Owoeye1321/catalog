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
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
      var items = (await repository.GetItemsAsync()).Select(item => item.parseDto());
      return items;
    }

    // /items/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
    {
      var item = await repository.GetItemAsync(id);
      if (item == null)
      {
        return NotFound();
      }
      return item.parseDto();
    }
    //POST /items
    [HttpPost]

    public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDtos itemDto)
    {
      Item item = new()
      {
        Id = Guid.NewGuid(),
        Name = itemDto.Name,
        Price = itemDto.Price,
        Description = itemDto.Description,
        CreatedDate = DateTimeOffset.UtcNow
      };
      await repository.CreateItemAsync(item);
      return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.parseDto());
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDtos itemDto)
    {
      var existingItem = await repository.GetItemAsync(id);
      if (existingItem is null) return NotFound();
      existingItem.Name = itemDto.Name;
      existingItem.Price = itemDto.Price;
      existingItem.Description = itemDto.Description;
      await repository.UpdateItemAsync(existingItem);
      return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItemAsync(Guid id)
    {
      var existingItem = await repository.GetItemAsync(id);
      if (existingItem is null) return NotFound();
      await repository.DeleteItemAsync(existingItem.Id);
      return NoContent();

    }
  }
}