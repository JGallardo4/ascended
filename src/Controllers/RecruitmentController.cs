using System.Collections.Generic;
using System.Threading.Tasks;
using AscendedGuild.Models;
using AscendedGuild.Models.Recruitement;
using AscendedGuild.ViewModels;
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

		/// <summary>
		///	Shows a grid with all player classes where the ones in demand
		/// are highlighted
		/// </summary>
		/// <remarks>
		/// The administrator account can update the chart
		/// </remarks>
		public IActionResult Index()
		{	
			var allClasses = _appDbContext
				.PlayerClasses
				.Include(p => p.Specs);

			var model =
				new RecruitmentViewModel
				{
					PlayerClasses = allClasses
				};

			return View(model);
		}

		/// <summary>
		///	Saves the changes made to the chart
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(IDictionary<int, DemandEnum> incomingSpecs)
		{
			if (ModelState.IsValid)
			{					
				foreach (KeyValuePair<int, DemandEnum> updateSpec in incomingSpecs)
				{
					var oldSpec = await _appDbContext.Specs.FindAsync(updateSpec.Key);

					oldSpec.Demand = updateSpec.Value;

					await TryUpdateModelAsync<Spec>(oldSpec,	"",	s => s.Demand);					
				}	
				
				await _appDbContext.SaveChangesAsync();
			}
			else
			{
				return NotFound();
			}

			return RedirectToAction("Index", "Recruitment");
		}
	}
}