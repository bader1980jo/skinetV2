using Core.Entities;
using Core.Interfaces;
using Infrastrcture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRep;
        
        public ProductsController(IGenericRepository<Product> productRepo, 
            IGenericRepository<ProductBrand> productBrandRepo, 
            IGenericRepository<ProductType> productTypeRep )
        {
            _productTypeRep = productTypeRep;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _productRepo.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _productRepo.GetyByIdAsync(id));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productBrandRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await _productTypeRep.ListAllAsync();
            return Ok(types);
        }
    }
}