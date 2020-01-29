using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class ClassAndSpec
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[NotMapped]
		public PlayerClass PlayerClass { get; set; }

		[NotMapped]
		public Spec Spec { get; set; }
	}
}