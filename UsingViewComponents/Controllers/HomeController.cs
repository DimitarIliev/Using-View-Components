﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    public class HomeController: Controller
    {
        private IProductRepository repository;

        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            repository.AddProduct(newProduct); //post redirect get pattern
            return RedirectToAction("Index");
        }
    }
}
