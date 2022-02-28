using Microsoft.EntityFrameworkCore;
using products_categories.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace products_categories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        // here we can "inject" our context service into the constructor
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            List<Product> allproducts = _context.Products.ToList();
            ViewBag.allproducts = allproducts;
            return View("index");
        }

        [HttpPost("newProduct")]
        public IActionResult NewProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            List<Product> allproducts = _context.Products.ToList();
            ViewBag.allproducts = allproducts;
            return View("index");
        }

        [HttpGet("addCategory")]
        public IActionResult AddCategory()
        {
            List<Category> allcategories = _context.Categories.ToList();
            ViewBag.allcategories = allcategories;
            return View("addCategory");
        }

        [HttpPost("newCategory")]
        public IActionResult NewCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            List<Category> allcategories = _context.Categories.ToList();
            ViewBag.allcategories = allcategories;
            return View("addCategory");
        }

        [HttpGet("oneProduct/{PID}")]
        public IActionResult OneProduct(int PID)
        {
            Product one = _context.Products.Include(p => p.Categories).ThenInclude(ti => ti.Category).FirstOrDefault(fd => fd.Productid == PID);
            ViewBag.AllCategories = _context.Categories.OrderBy(c => c.Categoryname).ToList();
            return View(one);

            //return View("oneProduct");
        }

        [HttpPost("prodAssociation")]
        public IActionResult ProdAssociation(Association prodAssociation)
        {
            {
                _context.Add(prodAssociation);
                _context.SaveChanges();
                return Redirect($"/oneProduct/{prodAssociation.Productid}");
            }

        }


        [HttpGet("oneCategory/{PID}")]
        public IActionResult OneCategory(int PID)
        {
            Category one = _context.Categories.Include(c => c.Products).ThenInclude(ti => ti.Product).FirstOrDefault(fd => fd.Categoryid == PID);
            ViewBag.AllProducts = _context.Products.OrderBy(p => p.Productname).ToList();
            return View(one);
        }

        
        [HttpPost("catgAssociation")]
        public IActionResult CatgAssociation(Association catgAssociation)
        {
            {
                _context.Add(catgAssociation);
                _context.SaveChanges();
                return Redirect($"/oneCategory/{catgAssociation.Productid}");
            }

        }
    }
}