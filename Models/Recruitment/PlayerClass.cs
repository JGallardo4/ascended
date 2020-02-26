using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models.Recruitement
{
	/// <summary>
	///	Represents a player class in World of Warcraft.
	/// </summary>
	/// <remarks>
	/// Contains all possible specializations for the class.
	/// </remarks>
	public class PlayerClass
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PlayerClassId { get; set; }

    [Required]
		[StringLength(100)]	
		public string ImageUrl { get; set; }

		[Required]
		[StringLength(100)]		
		public string Name { get; set; }

		public List<Spec> Specs { get; set; }

		public PlayerClass()
		{				
		}

		/// <summary>
	  ///	Returns true if any of the class' specs are in any demand.
	  /// </summary>
		public bool IsInDemand
		{
			get
			{
				return Specs.Exists(s => s.Demand != DemandEnum.CLOSED);
			}
		}
	}
}