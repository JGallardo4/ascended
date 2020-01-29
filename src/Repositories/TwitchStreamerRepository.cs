using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public class TwitchStreamerRepository : ITwitchStreamerRepository
	{
		private readonly AppDbContext _appDbContext;

		public TwitchStreamerRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<TwitchStreamer> AllTwitchStreamers
		 => _appDbContext.TwitchStreamers;

		public void AddTwitchStreamer(TwitchStreamer streamer)
		{
			throw new System.NotImplementedException();
		}

		public void RemoveTwitchStreamer(TwitchStreamer streamer)
		{
			throw new System.NotImplementedException();
		}
	}
}