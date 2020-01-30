using Microsoft.AspNetCore.Mvc;
using AscendedGuild.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
			var model = 
				new StreamsViewModel()
				{
					AllTwitchStreamers = _appDbContext.TwitchStreamers
						.Include(t => t.PlayerClass)
						.Include(t => t.Spec)
				};

			return View(model);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(AddStreamerViewModel model)
		{
			if (ModelState.IsValid)
			{
				var playerClass = 
					_appDbContext.PlayerClasses.SingleOrDefault(c => 
						c.Name == model.PlayerClass);
												
				var spec = 
					_appDbContext.Specs.SingleOrDefault(s => 
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
				_appDbContext.SaveChanges();
			}

			return RedirectToAction("Index", "Streams");
		}
	}
}