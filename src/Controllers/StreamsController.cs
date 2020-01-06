using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
	public class StreamsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}