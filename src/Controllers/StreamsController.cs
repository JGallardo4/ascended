using Microsoft.AspNetCore.Mvc;
using AscendedGuild.Models;
using System.Linq;

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
			var allStreamers = _appDbContext.TwitchStreamers;
		
			return View(
				new StreamsViewModel()
				{
					AllTwitchStreamers = allStreamers,
					NewStreamer = new NewStreamerData()
				}
			);
		}

		[HttpPost]
		public IActionResult Index(StreamsViewModel model)
		{
			var playerClass = 
				_appDbContext.PlayerClasses.SingleOrDefault(c => 
					c.Name == model.NewStreamer.PlayerClass);
                      
			var spec = 
				_appDbContext.Specs.SingleOrDefault(s => 
					s.Name == model.NewStreamer.Spec);
			
			var newStreamer = 
				new TwitchStreamer()
				{
					Channel = model.NewStreamer.Channel,
					GuildRank = model.NewStreamer.GuildRank,
					CharacterName = model.NewStreamer.CharacterName,
					ClassAndSpec = 
						new ClassAndSpec()
						{
							PlayerClass = playerClass,
							Spec = spec
						}		
				};
			
			_appDbContext.TwitchStreamers.Add(newStreamer);
			_appDbContext.SaveChanges();

			return View();
		}
	}
}