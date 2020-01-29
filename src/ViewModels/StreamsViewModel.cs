using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public class StreamsViewModel
	{
		public IEnumerable<TwitchStreamer> AllTwitchStreamers { get; set; }
		public NewTwitchStreamer NewTwitchStreamers { get; set; }
		public IEnumerable<string> TwitchStreamersToRemove { get; set; }
	}
}