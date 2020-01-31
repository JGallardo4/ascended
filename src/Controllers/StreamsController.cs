using Microsoft.AspNetCore.Mvc;
using AscendedGuild.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AscendedGuild.Controllers
{
	public class StreamsController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public StreamsController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		
		public IActionResult Index()
		{		
			var model = _appDbContext
				.TwitchStreamers
				.Include(t => t.PlayerClass)
				.Include(t => t.Spec);

			return View(model);
		}

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

		public IActionResult Create()
		{
			var model = new AddStreamerViewModel();

			return View(model);
		}

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

			return RedirectToAction("Index", "Streams");
		}
	}
}