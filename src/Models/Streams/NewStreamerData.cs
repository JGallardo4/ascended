using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class NewStreamerData
	{
		public string CharacterName { get; set; }
		public string GuildRank { get; set; }
		public string PlayerClass { get; set; }
		public string Spec { get; set; }
		public string Channel { get; set; }
	}
}