using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Anonymus;

public class ProductGet
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
