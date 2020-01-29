using Microsoft.AspNetCore.Mvc;
using AscendedGuild.Models;

namespace AscendedGuild.Controllers
{
	public class StreamsController : Controller
	{
		private readonly ITwitchStreamerRepository _twitchStreamerRepository;

		public StreamsController(ITwitchStreamerRepository twitchStreamerRepository)
		{
			_twitchStreamerRepository = twitchStreamerRepository;
		}

		
		public IActionResult Index()
		{
			var allStreamers = _twitchStreamerRepository.AllTwitchStreamers;
		
			return View(
				new StreamsViewModel()
				{
					AllTwitchStreamers = allStreamers,
					NewStreamer = new TwitchStreamer()
				}
			);
		}

		[HttpPost]
		public IActionResult Index(StreamsViewModel model)
		{
			_twitchStreamerRepository.AddTwitchStreamer(model.NewStreamer);
			return View();
		}
	}
}