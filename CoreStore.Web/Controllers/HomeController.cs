using System.Collections.Generic;
using CoreStore.Web.Core;
using CoreStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreStore.Web.Controllers
{
    public class HomeController: Controller
    {
        private IProductRepository productRepository;

        public HomeController(IProductRepository _pr)
        {
            productRepository = _pr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(productRepository.ListProducts());
        }

        public IActionResult Details(int id)
        {
            var product = productRepository.GetProductById(id);
            if (product == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(product);
            }
        }
    }
}