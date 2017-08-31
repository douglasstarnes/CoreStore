using System;
using System.Collections.Generic;
using CoreStore.Web.Controllers;
using CoreStore.Web.Core;
using CoreStore.Web.Infrastructure;
using CoreStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoreStore.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void VerifyIndexViewType()
        {
            var productRepository = new Mock<IProductRepository>();
            var controller = new HomeController(productRepository.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void VerifyListActionProductCount()
        {
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.ListProducts()).Returns(new List<Product> {
                new Product(), new Product(), new Product()
            });
            var controller = new HomeController(productRepository.Object);
            var result = Assert.IsType<ViewResult>(controller.List());
            var model = Assert.IsType<List<Product>>(result.Model);
            Assert.Equal(3, model.Count);
        }

        [Fact]
        public void VerifyDetailsActionReturnsProduct()
        {
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.GetProductById(It.IsAny<int>())).Returns(new Product {
                ID = 1, Name = "Apricots", Price = 1.00m
            });
            var controller = new HomeController(productRepository.Object);
            var result = Assert.IsType<ViewResult>(controller.Details(1));
            var model = Assert.IsType<Product>(result.Model);
            Assert.Equal("Apricots", model.Name);
        }
    }
}
