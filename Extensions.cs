using Catalog.Dtos;
using Catalog.Models;

namespace Catalog
{
  public static class Extentions
  {

    //the this in this parseData function means that the item parameter would have a method of parseData of this class 
    public static ItemDto parseDto(this Item item)
    {
      return new ItemDto(item.Id, item.Name,item.Description, item.Price, item.CreatedDate);
    }
  }
}