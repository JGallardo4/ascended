using System.ComponentModel.DataAnnotations;

namespace AscendedGuild.Models
{
	
	public class AddStreamerViewModel
	{
		[Required]
		public string CharacterName { get; set; }

		[Required]
		public string GuildRank { get; set; }

		[Required]
		public string PlayerClass { get; set; }

		[Required]
		public string Spec { get; set; }

		[Required]
		public string Channel { get; set; }
	}
}