using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AscendedGuild.Models.Streams;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AscendedGuild.ViewModels.Streams
{
	public class NewStreamer
	{
		[Required]
		[StringLength(100)]
		public string CharacterName { get; set; }

		[Required]
		public GuildRank GuildRank { get; set; }

		[Required]
		public string PlayerClass { get; set; }

		[Required]
		public string Spec { get; set; }

		[Required]
		[StringLength(100)]
		public string Channel { get; set; }
	}
	
	public class AddStreamerViewModel
	{
		public NewStreamer NewStreamer { get; set; }

		public IEnumerable<SelectListItem> PlayerClasses { get; set; }
	}
}