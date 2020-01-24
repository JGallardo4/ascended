using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public class PlayerClass
	{
		public int PlayerClassId { get; set; }
		public string ImageUrl { get; set; }
		public string Name { get; set; }

		// Specializations of the class
		// that may each be in a number
		// of states of demand.	
		public List<Spec> Specs { get; set; }

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