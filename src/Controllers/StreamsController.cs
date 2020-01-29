using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	public class StreamsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}