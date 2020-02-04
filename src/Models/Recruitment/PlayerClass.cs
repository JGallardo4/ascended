using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models.Recruitement
{
	public class PlayerClass
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PlayerClassId { get; set; }

        // REVIEW: Add attriutes here as well
		public string ImageUrl { get; set; }
		public string Name { get; set; }

		public List<Spec> Specs { get; set; }

		public PlayerClass()
		{				
		}

		// Returns true if any of the class'
		// specs are in any demand.
		public bool IsInDemand
		{
			get
			{
				return Specs.Exists(s => s.Demand != DemandEnum.CLOSED);
			}
		}
	}
}