using System.Threading.Tasks;
using AscendedGuild.Data;
using AscendedGuild.Models;
using AscendedGuild.Models.About;
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
		public async Task<IActionResult> IndexAsync()
		{
			// Retrieve about content
			var currentContent = _appDbContext.TextBlocks.Find(1);

			// Create content if none if found
			if (currentContent == null)
			{
				_appDbContext.TextBlocks.Add(new TextBlock(){
					TextBlockId = 1,
					Name = "About",
					MarkdownContent = "# Please write an about-us blurb and hit save #"
				});
				
				// Save changes to db
				await _appDbContext.SaveChangesAsync();
			}			

			return View(_appDbContext.TextBlocks.Find(1));
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
		public async Task<IActionResult> EditOrCreate(string incomingContent)
		{
			// Retrieve about content
			var currentContent = _appDbContext.TextBlocks.Find(1);

			// Create content if none if found
			if (currentContent == null)
			{
				_appDbContext.TextBlocks.Add(new TextBlock(){
					TextBlockId = 1,
					Name = "About",
					MarkdownContent = incomingContent
				});				
			}
			else
			{
				currentContent.MarkdownContent = incomingContent;

				_appDbContext.Update(currentContent);
			}
			
			// Save changes to db
			await _appDbContext.SaveChangesAsync();

			return RedirectToAction("Index", "About");
		}
	}
}