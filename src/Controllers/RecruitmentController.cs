using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
	public class RecruitmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}