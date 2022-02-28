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

        [HttpGet("oneProduct")]
        public IActionResult OneProduct()
        {
            List<Product> allproducts = _context.Products.ToList();
            ViewBag.allproducts = allproducts;
            List<Category> allcategories = _context.Categories.ToList();
            ViewBag.allcategories = allcategories;

            return View("oneProduct");
        }

        //   [HttpGet("/oneProduct/{dId}")]
        // public IActionResult OneProduct(int dId)
        // {
        //     Product one = _context.Products.FirstOrDefault(d => d.Productid == dId);
        //     if (one == null)
        //     {
        //         return RedirectToAction("index");
        //     }

        //     return View("Oneproduct",one);
        //}

        // [HttpPost("prodAssociation")]
        // public IActionResult ProdAssociation(Association prodAssociation)
        // {
        //     {
        //         _context.Add(prodAssociation);
        //         return RedirectToAction("index");
        //     }

        // }


        [HttpGet("oneCategory")]
        public IActionResult OneCategory()
        {
            List<Category> allcategories = _context.Categories.ToList();
            ViewBag.allcategories = allcategories;
            // ViewBag.OneProduct = _context.Products.Include(d => d.Preparer).OrderByDescending(d => d.CreatedAt).ToList();
            return View("oneCategory");
        }
    }
}