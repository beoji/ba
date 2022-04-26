using Microsoft.AspNetCore.Mvc;
using ba.Models;
using ba.Data;
using AutoMapper;
using ba.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace ba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepo _repository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
    {
        var productItems = _repository.GetAllProducts();
        return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
    }

    [HttpGet("{id}", Name="GetProductById")]
    public ActionResult<ProductReadDto> GetProductById(int id)
    {
        var productItem = _repository.GetProductById(id);
        if(productItem == null)
            return NotFound();
        return Ok(_mapper.Map<ProductReadDto>(productItem)); // HTTP 200
    }

    [HttpPost]
    public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Product>(productCreateDto);
        _repository.CreateProduct(product);
        _repository.SaveChanges();
        var productReadDto = _mapper.Map<ProductReadDto>(product);
        return CreatedAtRoute(nameof(GetProductById), new {Id = productReadDto.Id}, productReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
        var product = _repository.GetProductById(id);
        if (product is null)
            return NotFound();
        _mapper.Map(productUpdateDto, product);
        _repository.UpdateProduct(product);
        _repository.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
    {
        var product = _repository.GetProductById(id);
        if (product is null)
            return NotFound();
        var productToPatch = _mapper.Map<ProductUpdateDto>(product);

        patchDoc.ApplyTo(productToPatch, ModelState);
        if(!TryValidateModel(productToPatch))
            return ValidationProblem(ModelState);

        _mapper.Map(productToPatch, product);
        _repository.UpdateProduct(product);
        _repository.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = _repository.GetProductById(id);

        _repository.DeleteProduct(product);
        _repository.SaveChanges();
        
        return NoContent();
    }
}