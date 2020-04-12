using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NASAPOD.Infra.Dtos;
using NASAPOD.Infra.Services;
using NASAPOD.Models;
using System;
using System.Diagnostics;

namespace NASAPOD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApodService _apodService;

        public HomeController(ILogger<HomeController> logger, IApodService apodService)
        {
            _logger = logger;
            _apodService = apodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PictureOfDay([Bind("Date")] PictureOfDayFilter pictureOfDayFilter)
        {
            if (pictureOfDayFilter.Date > DateTime.Now)
            {
                pictureOfDayFilter.Date = DateTime.Now;
            }

            var getPictureOfDayFilter = new GetPictureOfDayFilter(pictureOfDayFilter.Date);

            var pictureOfDayDto = _apodService.GetPictureOfDay(getPictureOfDayFilter).GetAwaiter().GetResult();

            var pictureOfDayModel = new PictureOfDay
            {
                Copyright = pictureOfDayDto.Copyright,
                Date = pictureOfDayDto.Date,
                Explanation = pictureOfDayDto.Explanation,
                Hdurl = pictureOfDayDto.Hdurl,
                Media_type = pictureOfDayDto.Media_type,
                Service_version = pictureOfDayDto.Service_version,
                Title = pictureOfDayDto.Title,
                Url = pictureOfDayDto.Url
            };

            return View(pictureOfDayModel);
        }
    }
}
