using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class TwitchStreamer
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int Id { get; set; }
		
		public string Channel { get; set; }
		
		public string GuildRank { get; set; }
		
		public string CharacterName { get; set; }	

		public int ClassAndSpecId { get; set; }
		public ClassAndSpec ClassAndSpec { get; set; }
	}
}