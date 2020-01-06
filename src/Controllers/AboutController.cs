using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}