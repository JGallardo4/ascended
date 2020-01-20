using AscendedGuild.Models;
using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.Controllers
{
	public class RecruitmentController : Controller
	{
		private readonly IPlayerClassRepository _playerClassRepository;

		public RecruitmentController(IPlayerClassRepository playerClassRepository)
		{
			_playerClassRepository = playerClassRepository;
		}

		public IActionResult Index()
		{
			var playerClasses = _playerClassRepository.AllPlayerClasses;

			return View(
				new RecruitmentViewModel
				{
					PlayerClasses = playerClasses
				}
			);
		}
	}
}