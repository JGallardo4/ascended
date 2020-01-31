using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AscendedGuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			var allClasses = _appDbContext
				.PlayerClasses
				.Include(p => p.Specs);

			return View(allClasses);
		}

		public async Task<IActionResult> Update(IEnumerable<PlayerClass> allClasses)
		{
			if (ModelState.IsValid)
			{
				var allSpecs = allClasses.SelectMany(p => p.Specs);

				_appDbContext.UpdateRange(allSpecs);

				await _appDbContext.SaveChangesAsync();		
			}
			return RedirectToAction("Index", "Recruitment");
		}
	}
}