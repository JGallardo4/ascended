using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}