using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public class StreamsViewModel
	{
		public IEnumerable<TwitchStreamer> AllTwitchStreamers { get; set; }
		public TwitchStreamer NewStreamer { get; set; }
	}
}