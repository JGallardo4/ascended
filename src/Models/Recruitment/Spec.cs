using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class Spec
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SpecId { get; set; }

		public string ImageUrl { get; set; }

		public string Name { get; set; }	

		public DemandEnum Demand { get; set; }

		public int PlayerClassId { get; set; }
		public PlayerClass PlayerClass { get; set; }		
	}
}