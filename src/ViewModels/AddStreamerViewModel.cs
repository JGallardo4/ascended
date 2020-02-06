using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AscendedGuild.ViewModels
{
	public class NewStreamer
	{
		[Required]
		[StringLength(100)]
		public string CharacterName { get; set; }

		[Required]
		[StringLength(100)]
		public string GuildRank { get; set; }

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

		public IEnumerable<SelectListItem> Specs { get; set; }
	}
}