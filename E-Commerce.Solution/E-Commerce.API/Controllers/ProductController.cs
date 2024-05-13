using AutoMapper;
using E_Commerce.API.DTOs;
using E_Commerce.API.Errors;
using E_Commerce.API.Helpers;
using E_Commerce.Core.Entities;
using E_Commerce.Core.IRepositories;
using E_Commerce.Core.Specifications;
using E_Commerce.Core.Specifications.ProductSpecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace E_Commerce.API.Controllers
{
   
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandsRepo;
        private readonly IGenericRepository<ProductType> _typesRepo;
        private readonly IMapper _mapper;

        public ProductController(
            IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandsRepo,
            IGenericRepository<ProductType> typesRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _brandsRepo = brandsRepo;
            _typesRepo = typesRepo;
            _mapper = mapper;
        }

        [HttpGet]  // /api/product
        public async Task<ActionResult<PaginationStandardResponse<ProductToReturnDTO>>> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductWithBrandAndTypeSpecifications(specParams);

            var products = await _productRepo.GetAllWithSpecAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);

            var countSpec = new ProductsWithFilterationForCountSpecifications(specParams);

            var count = await _productRepo.GetCountAsync(countSpec);

            return Ok(new PaginationStandardResponse<ProductToReturnDTO>(specParams.PageIndex, specParams.PageSize, count, data));
        }

        [HttpGet("{id}")]  // /api/product/1
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecifications(id);

            var product = await _productRepo.GetWithSpecAsync(spec);
           
            if(product == null)
                return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Product, ProductToReturnDTO>(product));
        }


        [HttpGet("brands")] // //api/product/brands
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _brandsRepo.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")] // //api/product/types
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            var types = await _typesRepo.GetAllAsync();
            return Ok(types);
        }
    }
}
