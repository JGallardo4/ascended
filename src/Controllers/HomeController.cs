using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	/// <summary>
	///	Contains all actions for displaying the home page.
	/// </summary>
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
