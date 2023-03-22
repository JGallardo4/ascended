using System.Collections.Generic;
using System.Threading.Tasks;
using AscendedGuild.Data;
using AscendedGuild.Models.About;
using AscendedGuild.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Controllers
{
	/// <summary>
	///	Contains all actions for displaying, and updating the about-us blurb.
	/// </summary>
	public class AboutController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public AboutController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		/// <summary>
		///	Displays a blurb about the guild. 		
		/// </summary>
		/// <remarks>
		/// For the administrator, it also displays a text area to 
		/// update the About blurb using Markup.
		/// The database object containing the blurb data is created if not found.
		/// </remarks>
		public IActionResult Index()
		{
			var viewModel = new NewAboutViewModel()
			{
				AboutContent = _appDbContext.TextBlocks
			};
			
			return View(viewModel);
		}

		/// <summary>
		///	Updates the About blurb with the contents of the text area.
		/// </summary>
		/// <remarks>
		/// This action is only available to the administrator account.
		/// The database object containing the blurb data is created if not found.
		/// </remarks>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> EditOrCreate(IDictionary<int, string> incomingChanges)
		{
			if (ModelState.IsValid)
			{	
				foreach(KeyValuePair<int, string> newSectionInfo in incomingChanges)
				{				
					var oldSection = _appDbContext.TextBlocks.Find(newSectionInfo.Key);

					string newContent = 
						string.IsNullOrEmpty(newSectionInfo.Value) 
						? "Please add some content for this section and hit Save"
						: newSectionInfo.Value;

					oldSection.MarkdownContent = newContent;

					await TryUpdateModelAsync<TextBlock>(oldSection, "", o => o.MarkdownContent);
				}

				await _appDbContext.SaveChangesAsync();
			}
			else
			{
				return NotFound();
			}

			return RedirectToAction("Index", "About");
		}
	}
}