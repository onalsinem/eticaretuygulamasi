﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.ResultProductAsync();
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Başarı ile silindi");
        }

        [HttpPut]
        public async Task<IActionResult>UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Başarı ile güncellendi");
        }

        [HttpPost]
        public async Task<IActionResult> CreatProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Başarı ile eklendi");
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _productService.GetGetByIdProductAsync(id);
            return Ok(values);
        }


    }
}
