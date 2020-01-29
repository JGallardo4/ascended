using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class PlayerClass
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PlayerClassId { get; set; }

		public string ImageUrl { get; set; }
		public string Name { get; set; }

		public virtual List<Spec> Specs { get; set; }

		// Returns true if any of the class'
		// specs are in any demand.
		public bool IsInDemand
		{
			get
			{
				return Specs.Exists(s => 
					s.Demand == DemandEnum.Low 
					|| 
					s.Demand == DemandEnum.High);
			}
		}
	}
}