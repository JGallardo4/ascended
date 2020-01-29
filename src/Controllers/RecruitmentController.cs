using AscendedGuild.Models;
using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	public class RecruitmentController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public RecruitmentController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IActionResult Index()
		{
			var playerClasses = _appDbContext.PlayerClasses;
			var allSpecs = _appDbContext.Specs;

			return View(
				new RecruitmentViewModel
				{
					PlayerClasses = playerClasses,
					AllSpecs = allSpecs
				}
			);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Index(RecruitmentViewModel model)
		{
			if (ModelState.IsValid)
			{
				//_specRepository.UpdateSpec(model);
				return RedirectToAction("Index");
			}

			// If we got this far, something failed; redisplay form.
			return View(model);
		}
	}
}