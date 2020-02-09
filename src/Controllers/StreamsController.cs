using Microsoft.AspNetCore.Mvc;
using AscendedGuild.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AscendedGuild.ViewModels;
using AscendedGuild.Models.Streams;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
			// Populate dropdown menus
			var playerClasses = new List<SelectListItem>();
			
			playerClasses.Add(new SelectListItem()
				{
					Value = string.Empty,
					Text = "Select",
					Selected = true
				});
			
			playerClasses.AddRange(_appDbContext.PlayerClasses
				.Select(p => new SelectListItem()
					{
						Value = p.Name,
						Text = p.Name
					}
				)
			);

			var specs = new List<SelectListItem>();

			specs.Add(new SelectListItem()
				{
					Value = string.Empty,
					Text = "Select",
					Selected = true
				});

			specs.AddRange(_appDbContext.Specs
				.Select(s => new SelectListItem()
					{
						Value = s.Name,
						Text = s.Name
					}
				)
			);
			
			var model = 
				new AddStreamerViewModel()
				{
					NewStreamer = new NewStreamer(),
					PlayerClasses = playerClasses,
					Specs = specs
				};

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
						c.Name == model.NewStreamer.PlayerClass);
												
				var spec = await
					_appDbContext.Specs.SingleOrDefaultAsync(s => 
						s.Name == model.NewStreamer.Spec);

				var newStreamer = 
					new TwitchStreamer()
					{
						Channel = model.NewStreamer.Channel,
						GuildRank = model.NewStreamer.GuildRank,
						CharacterName = model.NewStreamer.CharacterName,						
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