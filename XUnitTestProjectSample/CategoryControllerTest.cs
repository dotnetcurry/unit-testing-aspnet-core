using Core_WebApp.Controllers;
using Core_WebApp.Models;
using Core_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProjectSample
{
    public class CategoryControllerTest
    {
        [Fact]
        public void Index_ReturnsViewResult_WithAListOfCategories()
        {
            // Arrange
            var mockRepo = new Mock<IService<Category, int>>();
            // define the setup on the mocked type
            mockRepo.Setup(repo => repo.GetAsync()).ReturnsAsync(GetTestCategories());
            var controller = new CategoryController(mockRepo.Object);
            // Act
            // call the Index() method from the controller
            var result = controller.Index().Result;
            //Asert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(
                viewResult.ViewData.Model
                );
            // Assert the model count
            Assert.Equal(2, model.Count());
        }

        private IEnumerable<Category> GetTestCategories()
        {
            return new List<Category>()
            {
                new Category(){CategoryRowId=1, CategoryId="Cat0001",CategoryName="Electronics",BasePrice=12000 },
                new Category(){CategoryRowId=2, CategoryId="Cat0002",CategoryName="Electrical",BasePrice=20 }
            };
     
        }
        private Category GetTestCategory()
        {
            return new Category()
            {
                CategoryId = "Cat001",
               // CategoryName = "ECT",
                BasePrice =2000
            };
        }
        [Fact]
        public void Create_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IService<Category,int>>();

            var controller = new CategoryAPIController(mockRepo.Object);
            controller.ModelState.AddModelError("CategoryName", "Required");
            var newCategory = GetTestCategory();

            // Act
            var result = controller.PostAsync(newCategory).Result;

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void Create_CategoryAndReturnsARedirect_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IService<Category,int>>();
            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Category>()))
                .Verifiable();
            var controller = new CategoryController(mockRepo.Object);
            var newEmployee = GetTestCategory();

            // Act
            var result = controller.Create(newEmployee).Result;

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

    }
}
