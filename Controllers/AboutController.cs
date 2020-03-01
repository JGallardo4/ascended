using System.Threading.Tasks;
using AscendedGuild.Data;
using AscendedGuild.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
			var viewModel = new AboutViewModel()
			{
				AboutContent = _appDbContext.TextBlocks,
				EditSectionDetails = new EditSectionDetails()
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
		public async Task<IActionResult> EditOrCreate(AboutViewModel model)
		{
			// Retrieve target section
			var targetSection = _appDbContext.TextBlocks.Find(model.EditSectionDetails.TargetAboutSection);
			
			targetSection.MarkdownContent = model.EditSectionDetails.NewSectionContent;

			_appDbContext.Update(targetSection);
			
			// Save changes to db
			await _appDbContext.SaveChangesAsync();

			return RedirectToAction("Index", "About");
		}
	}
}