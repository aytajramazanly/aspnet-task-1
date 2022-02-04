using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.DataAccessLayer;
using Task1.ViewModels;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.Include(x => x.Category).ToList();
            var categories = _dbContext.Categories.ToList();


            return View(new HomeViewModel { 
            Products=products,
            Categories=categories
            });
        }
    }
}
