using Core_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Services
{
    /// <summary>
    /// Inject the DbContext as constructor injectation
    /// </summary>
    public class CategoryService : IService<Category, int>
    {
        private readonly AppJune2020DbContext ctx;
        public CategoryService(AppJune2020DbContext ctx)
        {
            this.ctx = ctx;
        }
        /// <summary>
        /// async: The method will be containing the Asynchronous call
        /// and this method returns Task Object
        /// await: The statement performs Async operation on separate thread
        /// other than calling thread and the async method will returns response
        /// to the calling thread
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Category> CreateAsync(Category entity)
        {
            // new Category will be added in DbSet
            var result = await ctx.Categories.AddAsync(entity);
            // the transaction will be commited by adding new category in
            // Categories table
            await ctx.SaveChangesAsync();
            // newly created Category will be returned
            return result.Entity;
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            // seacrh record based on Primary key
            var cat = await ctx.Categories.FindAsync();
            if (cat != null)
            {
                // remove the object
                ctx.Categories.Remove(cat);
                await ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await ctx.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await ctx.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(int id, Category entity)
        {
            // seacrh record based on Primary key
            var cat = await ctx.Categories.FindAsync(id);
            if (cat != null)
            {
                cat.CategoryId = entity.CategoryId;
                cat.CategoryName = entity.CategoryName;
                cat.BasePrice = entity.BasePrice;
                await ctx.SaveChangesAsync();
            }
            return cat;
        }
    }
}
