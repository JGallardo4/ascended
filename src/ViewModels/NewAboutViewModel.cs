using System.Collections.Generic;
using AscendedGuild.Models.About;

namespace AscendedGuild.ViewModels.About
{
	public class NewAboutViewModel
	{
		public IEnumerable<TextBlock> AboutContent { get; set; }
	}
}