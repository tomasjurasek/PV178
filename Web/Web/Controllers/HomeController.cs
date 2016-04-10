using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryFacade categoryFacade;
        private readonly ProductFacade productFacade;

        public HomeController(CategoryFacade categoryFacade, ProductFacade productFacade)
        {
            this.productFacade = productFacade;
            this.categoryFacade = categoryFacade;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            var productViewModel = new ProductViewModel()
            {
                Products = productFacade.GetAllProducts(),
                Categories = categoryFacade.GetAllCategories()
            };
            return View(productViewModel);
        }

        public ActionResult ProductsByCategory(int categoryId)
        {
            var productViewModel = new ProductViewModel()
            {
                Products = productFacade.GetProductsByCategory(categoryId),
                Categories = categoryFacade.GetAllCategories()
            };
            return View("Products",productViewModel);
        }

        public ActionResult Edit(int id)
        {
            var product = productFacade.GetProductById(id);
            var productEditViewModel = new ProductEditViewModel()
            {
                Product = product,
                SelectedCategories = product.Categories.Select(s => s.Id).ToArray(),
                Categories = categoryFacade.GetAllCategories()

            };
            
            return View(productEditViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ProductEditViewModel model)
        {
            productFacade.UpdateProduct(model.Product, model.SelectedCategories);
            return RedirectToAction("Products");
        }

        public ActionResult Create()
        {
            var productEditViewModel = new ProductEditViewModel()
            {
                Product = new BL.DTO.ProductDTO(),

                Categories = categoryFacade.GetAllCategories()

            };
            return View(productEditViewModel);
        }
        [HttpPost]
        public ActionResult Create(ProductEditViewModel model)
        {
            productFacade.CreateProduct(model.Product, model.SelectedCategories);
            return RedirectToAction("Products");
        }


    }
}