using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;
using Core_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly IService<Category, int> catService;
        public CategoryAPIController(IService<Category, int> catService)
        {
            this.catService = catService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var cats = await catService.GetAsync();
            return Ok(cats);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var cat = await catService.GetAsync(id);
            if (cat == null) return NotFound($"Category based on Category Row Id {id} is removed");
            return Ok(cat);
        }
      //  [HttpPost("{categoryId}/{categoryName}/{basePrice}")]
        //  public async Task<IActionResult> PostAsync(Category category)
        // public async Task<IActionResult> PostAsync([FromQuery]Category category)
       // public async Task<IActionResult> PostAsync([FromRoute] Category category)
        [HttpPost]
        public async Task<IActionResult> PostAsync(Category category)
        {
            //var category = new Category()
            //{
            //     CategoryId = categoryId,
            //     CategoryName = categoryName,
            //     BasePrice = basePrice
            //};
            if (ModelState.IsValid)
            {
                if (category.BasePrice < 0) throw new Exception("Base Price is wrong");
                var cat = await catService.CreateAsync(category);
                return Ok(cat); 
            }
            return BadRequest(ModelState);
        }
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                var cat = await catService.UpdateAsync(id,category);
                return Ok(cat);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
                var res = await catService.DeleteAsync(id);
                return Ok(res);
        }
    }
}
