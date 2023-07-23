using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ctd.Controllers
{
    public class CaiThienDiemController : Controller
    {
        public IActionResult Index(int currentIndex, string btn)
        {
            List<string> imageUrls = new List<string>
            {
                "https://cdn.britannica.com/84/73184-050-05ED59CB/Sunflower-field-Fargo-North-Dakota.jpg",
                "https://www.imgonline.com.ua/examples/red-yellow-flower.jpg",
                "https://www.imgonline.com.ua/examples/rays-of-light-in-the-sky-HDR.jpg"
            };

            if (btn == "pre")
            {
                currentIndex = (currentIndex - 1 + imageUrls.Count) % imageUrls.Count;
            }
            else if (btn == "next")
            {
                currentIndex = (currentIndex + 1) % imageUrls.Count;
            }

            ViewBag.CurrentIndex = currentIndex;

            return View(imageUrls);
        }
    }
}
