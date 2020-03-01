using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AscendedGuild.Models.About;
using Microsoft.AspNetCore.Mvc;

namespace AscendedGuild.ViewModels.About
{
	public class AboutViewModel
	{
		[Required]
		public IEnumerable<TextBlock> AboutContent { get; set; }

		[Required]
		public EditSectionDetails EditSectionDetails { get; set; }
	}

	public class EditSectionDetails
	{
		[HiddenInput]
		[Required]
		public int TargetAboutSection { get; set; }

		[MaxLength(1000)]
		public string NewSectionContent { get; set; }
	}
}