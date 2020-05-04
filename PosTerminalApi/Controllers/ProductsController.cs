using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PosTerminalApi.Resources;
using PosTerminalApi.Validators;

namespace PosTerminalApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Retrieves all existing products details
        /// </summary>
        /// <returns>All existing products</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productService.GetAllWithProduct();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return Ok(productResources);
        }

        /// <summary>
        /// Retrieves a specific product detail
        /// </summary>
        /// <remarks>
        /// Note that the key is the Id of the product.
        ///  
        ///     GET 
        ///     {
        ///        "Id": 1,
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Selected product Item</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        /// <summary>
        /// Retrieves a specific product detail
        /// </summary>
        /// <remarks>
        /// Note that the key is the Code Name of the product.
        ///  
        ///     GET 
        ///     {
        ///        "CodeName": "A",
        ///     }
        /// 
        /// </remarks>
        /// <param name="code"></param>
        /// <returns>Selected product Item</returns>
        [HttpGet("{code}/ProductCode")]
        public async Task<ActionResult<ProductResource>> GetProductByCode(string code)
        {
            var product = await _productService.GetProductByCode(code);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        /// <summary>
        /// Creates a specific Product 
        /// </summary>
        /// <remarks>
        /// Note that the key is the Id of the Product.
        ///  
        ///     POST 
        ///     {
        ///             "id": 6,
        ///             "codeName": "G",
        ///             "unitPrice": 1,
        ///             "discountQtyBase": 5,
        ///             "unitDiscount": 4,
        ///             "farmProducer":"John Barry"
        ///     }
        /// 
        /// </remarks>
        /// <returns>New created product</returns>
        [HttpPost("")]
        public async Task<ActionResult<ProductResource>> CreateProduct([FromBody] SaveProductResource saveProductResource)
        {
            var validator = new SaveProductResourceValidator();
            var validationResult = await validator.ValidateAsync(saveProductResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var productToCreate = _mapper.Map<SaveProductResource, Product>(saveProductResource);

            var newProduct = await _productService.CreateProduct(productToCreate);

            var product = await _productService.GetProductById(newProduct.Id);

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        /// <summary>
        /// Updates a specific product 
        /// </summary>
        /// <remarks>
        /// Note that the key is the Id of the Product.
        ///  
        ///     PUT 
        ///     {
        ///             "id": 1,
        ///             "codeName": "A",
        ///             "unitPrice": 1.25,
        ///             "discountQtyBase": 3,
        ///             "unitDiscount": 
        ///     }
        /// 
        /// </remarks>
        /// <returns>Updated existing product</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResource>> UpdateProduct(int id, [FromBody] SaveProductResource saveProductResource)
        {
            var existingProductDetail = await _productService.GetProductById(id);
            if (existingProductDetail != null)
            {
                if (saveProductResource.Id == 0) saveProductResource.Id = existingProductDetail.Id;
                if (saveProductResource.CodeName == "string") saveProductResource.CodeName = existingProductDetail.CodeName;
                if (saveProductResource.DiscountQtyBase == 0) saveProductResource.DiscountQtyBase = existingProductDetail.DiscountQtyBase;
                if (saveProductResource.UnitDiscount == 0) saveProductResource.UnitDiscount = existingProductDetail.UnitDiscount;
                if (saveProductResource.UnitPrice == 0) saveProductResource.UnitPrice = existingProductDetail.UnitPrice;
                if (saveProductResource.FarmProducer == "string") saveProductResource.FarmProducer = existingProductDetail.FarmProducer;
            }
            var validator = new SaveProductResourceValidator();
            var validationResult = await validator.ValidateAsync(saveProductResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var productToBeUpdate = await _productService.GetProductById(id);

            if (productToBeUpdate == null)
                return NotFound();

            var product = _mapper.Map<SaveProductResource, Product>(saveProductResource);

            await _productService.UpdateProduct(productToBeUpdate, product);

            var updatedProduct = await _productService.GetProductById(id);
            var updatedProductResource = _mapper.Map<Product, ProductResource>(updatedProduct);

            return Ok(updatedProductResource);
        }

        /// <summary>
        /// Deletes a specific product 
        /// </summary>
        /// <remarks>
        /// Note that the key is the Id of the Product.
        ///  
        ///     DELETE 
        ///     {
        ///           "id": 1,
        ///     }
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Deleted existing product</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest();

            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteProduct(product);

            return NoContent();
        }
    }
}