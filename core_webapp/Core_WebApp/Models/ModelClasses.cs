using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Models
{
    public class Category
    {
        [Key] // thy primary identity key
        public int CategoryRowId { get; set; }
        [Required(ErrorMessage ="Category Id is must")]
        [StringLength(20)] // at max only 20 characters are allowed
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is must")]
        [StringLength(200)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage ="base Price Cannot be null")]
        public int BasePrice { get; set; }
        // One-to-Many relationship
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        [Required(ErrorMessage ="Product Id is must")]
        [StringLength(20)]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is must")]
        [StringLength(200)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is must")]
        [StringLength(300)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is must")]
        public int Price { get; set; }
        [ForeignKey("CategoryRowId")] // reference of CategoryRowId
        public int CategoryRowId { get; set; }
        // One-to-One Relationship
        public Category Category { get; set; }
    }
}
