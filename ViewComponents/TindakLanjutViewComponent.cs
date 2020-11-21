using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoMapSf.ViewComponents
{
    public class TindakLanjutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int number)
        {
            return View(number == 1);
        }
    }
}