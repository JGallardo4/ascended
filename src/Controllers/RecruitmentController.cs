using System.Linq;
using AscendedGuild.Models;
using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	public class RecruitmentController : Controller
	{
		private readonly IPlayerClassRepository _playerClassRepository;
		private readonly ISpecRepository _specRepository;

		public RecruitmentController(IPlayerClassRepository playerClassRepository, ISpecRepository specRepository)
		{
			_playerClassRepository = playerClassRepository;
			_specRepository = specRepository;
		}

		public IActionResult Index()
		{
			var playerClasses = _playerClassRepository.AllPlayerClasses;
			var allSpecs = _specRepository.AllSpecs;

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