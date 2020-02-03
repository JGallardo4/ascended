using System.Threading.Tasks;
using AscendedGuild.Models;
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