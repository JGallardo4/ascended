using System.Collections.Generic;
using AscendedGuild.Models.Recruitement;

namespace AscendedGuild.ViewModels
{
	public class RecruitmentViewModel
	{
		public IEnumerable<PlayerClass> PlayerClasses { get; set; }		

		public RecruitmentViewModel()
		{				
		}
	}
}