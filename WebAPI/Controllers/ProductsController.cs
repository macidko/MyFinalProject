using Business.Abstracts;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ATTRIBUTE(JAVA-ANNOTATION) : class ile ilgili bilgi verme, imzalama
    public class ProductsController : ControllerBase //Controller olabilmesi için controllerbase olmalı
    {
        //loosely coupled -- gevşek bağlılık (soyuta bağlılık)
        //bir katman diğer katmanın interface olmayanlar dışında bağlantı kuramazsın?
        //naming convention 
        //IoC Container -- Inversion of Control
        IProductService _productService;//field
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            //Swagger
            //hiçbir katman diğerini newlemiyor. somut katmanlar üzerinden gidilmemeli.
            //Dependency chain -- bağımlılık zinciri
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            //System.InvalidOperationException: Unable to resolve service for type 'Business.Abstracts.IProductService'


        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
