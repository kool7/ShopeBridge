using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Contracts.Products;
using ShopBridge.Modals;

namespace ShopBridge.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
        var products = await _productRepository.GetProducts();
        return Ok(_mapper.Map<IEnumerable<ReadProductDto>>(products));
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ReadProductDto>> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return Ok(_mapper.Map<ReadProductDto>(product));
        }

        return NotFound();
    }

}