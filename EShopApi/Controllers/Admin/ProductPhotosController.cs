using Core.IServices.Admin;

namespace Application.Controllers.Admin;

public class ProductPhotosController(IProductPhotosService productPhotosService) : AdminController
{
    private readonly IProductPhotosService _productPhotosService = productPhotosService;
}
