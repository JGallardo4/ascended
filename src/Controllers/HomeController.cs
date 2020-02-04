using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
