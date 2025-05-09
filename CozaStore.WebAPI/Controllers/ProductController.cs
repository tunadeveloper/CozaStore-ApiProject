﻿using CozaStore.BusinessLayer.Abstract;
using CozaStore.DtoLayer.ProductDtos;
using CozaStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product();

            product.CategoryID = createProductDto.CategoryID;
            product.Price = createProductDto.Price;
            product.Description = createProductDto.Description;
            product.Title = createProductDto.Title;
            product.ImageURL = createProductDto.ImageURL;
            product.ImageURL2 = createProductDto.ImageURL2;
            product.ImageURL3 = createProductDto.ImageURL3;
            product.IsPopular = createProductDto.IsPopular;

            _productService.TInsert(product);
            return Ok("Veri ekleme işlemi gerçekleşti!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
           _productService.TDelete(id);
            return Ok("Veri silme işlemi gerçekleşti!");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product();
            product.ID = updateProductDto.ID;
            product.Price = updateProductDto.Price;
            product.Description = updateProductDto.Description;
            product.Title = updateProductDto.Title;
            product.ImageURL= updateProductDto.ImageURL;
            product.ImageURL2 = updateProductDto.ImageURL2;
            product.ImageURL3 = updateProductDto.ImageURL3;
            product.CategoryID= updateProductDto.CategoryID;
            product.IsPopular= updateProductDto.IsPopular;
            _productService.TUpdate(product);
            return Ok("Veri güncelleme işlemi gerçekleşti!");
        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var values = _productService.TGetAll().Where(p => p.CategoryID == categoryId);
            return Ok(values);
        }

        [HttpGet("Count")]
        public IActionResult GetProductCount()
        {
            var productCount = _productService.TGetAll().Count();
            return Ok(productCount);
        }
    }
}
