using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AscendedGuild.Models.Recruitement;

namespace AscendedGuild.Models.Streams
{

	public enum GuildRank
	{
		[Display(Name="Guild Master")]
		GUILD_MASTER, 

		[Display(Name="Grand Master")]
		CO_GUILD_MASTER, 

		[Display(Name="Officer")]
		OFFICER, 

		[Display(Name="Paragon")]
		PARAGON, 

		[Display(Name="Raider")]
		RAIDER
	}

	/// <summary>
	///	Represents a member of the guild who is also
	/// an active streamer on Twitch.tv
	/// </summary>
	public class TwitchStreamer
	{		
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		
		public int TwitchStreamerId { get; set; }
		
		[Required]
		[StringLength(100)]	
		public string Channel { get; set; }
		
		[Required]
		public GuildRank GuildRank { get; set; }
		
		[Required]
		[StringLength(100)]	
		public string CharacterName { get; set; }

		public int PlayerClassId { get; set; }
		
		[Required]
		public PlayerClass PlayerClass { get; set; }

		public int SpecId { get; set; }
		
		public Spec Spec { get; set; }

		public TwitchStreamer()
		{				
		}
	}
}