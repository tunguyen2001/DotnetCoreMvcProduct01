using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProduct1.Data;
using WebProduct1.Models;
using WebProduct1.Services;

namespace WebProduct1.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(ProductSearch productSearch)
        {
            ViewData["product"] = _productService.GetProducts();
            ViewData["category"] = _categoryService.GetCategories();

            ViewData["productSearch"] = productSearch;
            var productSearch_ = _productService.SearchProduct(productSearch);

            return View(productSearch_);
        }

        public IActionResult Save(Product product)
        {
            if(product.Id == 0)
            {
                _productService.CreateProduct(product);
            }
            else
            {
                _productService.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }

        //// GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var products = _productService.GetProducts();
            ViewData["productDetail"] = products;
            var categories = _categoryService.GetCategories();
            ViewData["categoryDetail"] = categories;

            if ( id == null )
            {
                return NotFound();
            }

            var productCurrent = _productService.GetProductId(id);

            if (productCurrent == null)
            {
                return NotFound();
            }

            return View(productCurrent);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            var categories = _categoryService.GetCategories();
            ViewData["catCreate"] = categories;
            var producs = _productService.GetProducts();
            ViewData["proCreate"] = producs;
            return View();
        }

        public IActionResult Edit(int id)
        {
            var categories = _categoryService.GetCategories();
            ViewData["categoriesEdit"] = categories;
            var products = _productService.GetProducts();
            ViewData["productsEdit"] = products;
            
            var currentProduct = _productService.GetProductId(id);

            if(currentProduct == null )
            {
                return View("Create");
            }
            else
            {
                return View(currentProduct);
            }

        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {
            var ProDel = _productService.GetProductId(id);
            return View(ProDel);
        }

        public IActionResult AcceptDelete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToActionPermanent("Index");
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
