using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class TwitchStreamer
	{
		public int Id { get; set; }
		public string CharacterName { get; set; }
		public PlayerClass PlayerClass { get; set; }
		[NotMapped]
		public Spec Spec { get; set; }
		public string Channel { get; set; }
	}
}