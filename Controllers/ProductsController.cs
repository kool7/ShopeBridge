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

    [HttpGet("{id}", Name = "GetProductByIdAsync")]
    public async Task<ActionResult<ReadProductDto>> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return Ok(_mapper.Map<ReadProductDto>(product));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ReadProductDto>> CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _productRepository.CreateProduct(product);
        await _productRepository.SaveChanges();

        var productReadDto = _mapper.Map<ReadProductDto>(product);

        return CreatedAtRoute(nameof(GetProductByIdAsync), new { Id = productReadDto.Id}, productReadDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProductAsync(int Id, UpdateProductDto updateProductDto)
    {
        var productReadDto = await _productRepository.GetProductById(Id);

        if (productReadDto == null)
        {
            return NotFound();
        }

        _mapper.Map(updateProductDto, productReadDto);
        await _productRepository.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var productReadDto = await _productRepository.GetProductById(id);
        if(productReadDto == null)
        {
            return NotFound();
        }
        _productRepository.DeleteProduct(productReadDto);
        await _productRepository.SaveChanges();
        return NoContent();
    }

}