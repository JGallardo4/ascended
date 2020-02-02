using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class TwitchStreamer
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int TwitchStreamerId { get; set; }
		
		public string Channel { get; set; }
		
		public string GuildRank { get; set; }
		
		public string CharacterName { get; set; }

		public int PlayerClassId { get; set; }
		public PlayerClass PlayerClass { get; set; }

		public int SpecId { get; set; }
		public Spec Spec { get; set; }

		public TwitchStreamer()
		{				
		}
	}
}