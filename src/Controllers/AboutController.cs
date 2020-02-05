using System.Threading.Tasks;
using AscendedGuild.Models;
using AscendedGuild.Models.About;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Controllers
{
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
		/// For the administrator, it also displays
		/// a text area to update the About blurb
		/// using Markup
		/// </remarks>
		public async Task<IActionResult> Index()
		{
			var currentContent = await _appDbContext
				.TextBlocks
				.FirstOrDefaultAsync(t => t.Name == "About");
			
			if (currentContent == null)
			{
				_appDbContext.TextBlocks
					.Add(
						new TextBlock()
						{
							Name = "About",
							MarkdownContent = "# Please write an about-us blurb and hit save #"							
						}
					);
					
				await TryUpdateModelAsync<TextBlock>(currentContent, "", c => c.MarkdownContent);
			}			

			currentContent = await _appDbContext
				.TextBlocks
				.FirstOrDefaultAsync(t => t.Name == "About");		

			return View(currentContent);
		}

		/// <summary>
		///	Updates the About blurb with the contents of the text area. 		
		/// </summary>
		/// <remarks>
		/// This is only available to the administrator account.
		/// </remarks>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string incomingContent)
		{
			// Check if page content exists in the database
			var currentContent = await _appDbContext
				.TextBlocks
				.FirstOrDefaultAsync(t => t.Name == "About");

			if (currentContent != null)
			{
				currentContent.MarkdownContent = incomingContent;

				await TryUpdateModelAsync<TextBlock>(currentContent, "", c => c.MarkdownContent);
			}
			else
			{
				// Throw exception
			}

			await _appDbContext.SaveChangesAsync();

			return RedirectToAction("Index", "About");
		}
	}
}