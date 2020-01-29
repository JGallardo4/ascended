using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class ClassAndSpec
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClassAndSpecId { get; set; }

		public int PlayerClassId { get; set; }		
		public PlayerClass PlayerClass { get; set; }
		
		public int SpecId { get; set; }		
		public Spec Spec { get; set; }
	}
}