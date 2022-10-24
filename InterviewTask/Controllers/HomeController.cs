using InterviewTask.Filters;
using InterviewTask.Models;
using InterviewTask.OpenWeather.Services;
using InterviewTask.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelperServiceCardService helperServiceCardService;

        public HomeController(IHelperServiceCardService helperServiceCardService)
        {
            this.helperServiceCardService = helperServiceCardService;
        }

        [UnhandledException]
       [PageLogger]
        public ActionResult Index()
        {
            var model = new HelperServiceViewModel();
            int u = Convert.ToInt32("");// Error line  

            model.HelperServices = helperServiceCardService.Get();

            return View(model);
        }

        [UnhandledException]
        [PageLogger]
        public async Task<ActionResult> GetWeather()
        {
            var model = new HelperServiceViewModel();

            model.HelperServices = await helperServiceCardService.GetWithWeatherAsync();

            return View("Index", model);
        }

        //public ActionResult Error()
        //{
        //    return View();
        //}
    }
}