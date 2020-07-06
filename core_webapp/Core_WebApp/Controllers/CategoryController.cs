using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_WebApp.Models;
using Core_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_WebApp.Controllers
{
    /// <summary>
    /// Contains action methods (methods those will be executed over HttpRequest)
    /// ActionMethos can be either HttpGet (Default) or HttpPost(HttpPut/HttpDelete)
    /// ActionMethod Retuens IActionResult interface
    /// </summary>
    public class CategoryController : Controller
    {
        private readonly IService<Category, int> catRepository;
        /// <summary>
        /// Inject the CategoryRepository as constructor injection
        /// </summary>
        public CategoryController(IService<Category, int> catRepository)
        {
            this.catRepository = catRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cats = await catRepository.GetAsync();
            return View(cats);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            // check if the Cateogry Posted Model is valid
            if (ModelState.IsValid)
            {
                // create a new Category Record
                category = await catRepository.CreateAsync(category);
                // redirect to Index Page
                return RedirectToAction("Index");
            }
            else
            {
                // else stey on the same page with errors
                return View(category);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            // search the record being edited
            var cat = await catRepository.GetAsync(id);
            // return a view with record being edited
            return View(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            // check if the Cateogry Posted Model is valid
            if (ModelState.IsValid)
            {
                // update the Category Record
                category = await catRepository.UpdateAsync(id,category);
                // redirect to Index Page
                return RedirectToAction("Index");
            }
            else
            {
                // else stey on the same page with errors
                return View(category);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            // search the record being edited
            var res = await catRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
