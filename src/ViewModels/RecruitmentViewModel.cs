using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public class RecruitmentViewModel
	{
		public IEnumerable<PlayerClass> PlayerClasses { get; set; }
		public IEnumerable<Spec> AllSpecs { get; set; }
	}
}