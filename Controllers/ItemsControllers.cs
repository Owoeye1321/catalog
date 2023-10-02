using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Models;

namespace Catalog.Controllers
{
  //this brings a bunch of additional default behaviour for your controller 
  [ApiController]
  //adding a route
  //[Route("[controller]")] //this would make the route inherit the controller name e.g GET /items
  [Route("items ")]
  public class ItemController : ControllerBase
  {

    private readonly InMemItemsRepositories repository;
    public ItemController()
    {
      repository = new InMemItemsRepositories();
    }
    //define the method type here
    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
      var items = repository.GetItems();
      return items;
    }

    // /items/{id}
    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id)
    {
      var item = repository.GetItem(id);
      if (item == null)
      {
        return NotFound();
      }
      return item;
    }
  }
}