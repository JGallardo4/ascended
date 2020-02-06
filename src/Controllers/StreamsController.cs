using Microsoft.AspNetCore.Mvc;
using AscendedGuild.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AscendedGuild.ViewModels;
using AscendedGuild.Models.Streams;

namespace AscendedGuild.Controllers
{
	public class StreamsController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public StreamsController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		
		/// <summary>
		///	Shows a list of streamers in the guild each with a Twitch embed
		/// </summary>
		/// <remarks>
		public IActionResult Index()
		{		
			var model = _appDbContext
				.TwitchStreamers
				.Include(t => t.PlayerClass)
				.Include(t => t.Spec);

			return View(model);
		}

		/// <summary>
		///	Removes the streamer from the database
		/// </summary>
		/// <remarks>
		/// This action is only available to the administrator account.
		/// </remarks>
		public async Task<IActionResult> Delete(int id)
		{
			var twitchStreamer = _appDbContext
				.TwitchStreamers
				.FindAsync(id).Result;
				
			_appDbContext.TwitchStreamers
				.Remove(twitchStreamer);
				
			await _appDbContext.SaveChangesAsync();		
			
			return RedirectToAction("Index", "Streams");
		}

		/// <summary>
		///	Shows a form to add a new streamer to the database.
		/// </summary>
		/// <remarks>
		/// This action is only available to the administrator account.
		/// </remarks>
		public IActionResult Create()
		{
			var model = new AddStreamerViewModel();

			return View(model);
		}

		/// <summary>
		///	Adds a new streamer to the database.
		/// </summary>
		/// <remarks>
		/// This action is only available to the administrator account.
		/// </remarks>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AddStreamerViewModel model)
		{
			if (ModelState.IsValid)
			{
				var playerClass = await
					_appDbContext.PlayerClasses.SingleOrDefaultAsync(c => 
						c.Name == model.PlayerClass);
												
				var spec = await
					_appDbContext.Specs.SingleOrDefaultAsync(s => 
						s.Name == model.Spec);

				if (playerClass == null || spec == null)
				{
					return NotFound();
				}

				var newStreamer = 
					new TwitchStreamer()
					{
						Channel = model.Channel,
						GuildRank = model.GuildRank,
						CharacterName = model.CharacterName,						
						PlayerClass = playerClass,
						Spec = spec						
					};
				
				_appDbContext.TwitchStreamers.Add(newStreamer);
				await _appDbContext.SaveChangesAsync();
			}
			else
			{
				// Throw exception
			}

			return RedirectToAction("Index", "Streams");
		}
	}
}