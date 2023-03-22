using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models.Recruitement
{
	public enum DemandEnum
	{
		CLOSED, LOW, HIGH
	}

	/// <summary>
	///	Represents a specialization of a player class in World of Warcraft.
	/// </summary>
	public class Spec
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SpecId { get; set; }
    	
		[StringLength(100)]	
		public string ImageUrl { get; set; }

		[Required]
		[StringLength(100)]	
		public string Name { get; set; }	

		[Required]
		public DemandEnum Demand { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PlayerClassId { get; set; }

		[Required]
		public PlayerClass PlayerClass { get; set; }		

		public Spec()
		{				
		}
	}
}