using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public interface ITwitchStreamerRepository
	{
		IEnumerable<TwitchStreamer> AllTwitchStreamers { get; }

		void AddTwitchStreamer(TwitchStreamer streamer);

		void RemoveTwitchStreamer(TwitchStreamer streamer);	
	}
}