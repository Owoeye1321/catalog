using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
   public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset createdDate);
  public record CreateItemDtos([Required] string Name, string Description, [Range(1,1000)]decimal Price);
  public record UpdateItemDtos([Required] string Name, string Description, [Range(1,1000)]decimal Price);
}