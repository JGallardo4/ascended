using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
	public class ApplyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}