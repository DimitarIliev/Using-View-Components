using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary: ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        //public IViewComponentResult Invoke()
        //{
        //    return View(new CityViewModel
        //    {
        //        Cities = repository.Cities.Count(),
        //        Population = repository.Cities.Sum(x => x.Population)
        //    });
        //}

        //public IViewComponentResult Invoke()
        //{
        //    return Content("This is a <h3><i>string</i></h3>"); //string is encoded to make it safe to include in an HTML document
        //}

        //public IViewComponentResult Invoke()
        //{
        //    return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>")); //returning a trusted HTML fragment
        //}

        //public IViewComponentResult Invoke()
        //{
        //    var target = RouteData.Values["id"] as string;
        //    var cities = repository.Cities.Where(x => target == null || string.Compare(x.Country, target, true) == 0);
        //    return View(new CityViewModel
        //    {
        //        Cities = cities.Count(),
        //        Population = cities.Sum(x => x.Population)
        //    });
        //}

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
                return View("CityList", repository.Cities);
            else
                return View(new CityViewModel
                {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(x => x.Population)
                });
        }
    }
}
