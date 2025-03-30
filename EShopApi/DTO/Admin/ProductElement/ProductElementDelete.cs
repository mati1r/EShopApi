﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Admin.ProductElement;

public class ProductElementDelete
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}
