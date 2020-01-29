using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class TwitchStreamer
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string CharacterName { get; set; }
		public string GuildRank { get; set; }
		public PlayerClass PlayerClass { get; set; }
		[NotMapped]
		public Spec Spec { get; set; }
		public string Channel { get; set; }
	}
}