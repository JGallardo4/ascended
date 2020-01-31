using System.Collections.Generic;
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
			var model = 
				new RecruitmentViewModel
				{
					PlayerClasses = 
						_appDbContext.PlayerClasses
							.Include(p => p.Specs)
				};

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Index(RecruitmentViewModel model)
		{
			if (ModelState.IsValid)
			{
				//_appDbContext.Update();
				return RedirectToAction("Index");
			}

			// If we got this far, something failed; redisplay form.
			return View(model);
		}
	}
}