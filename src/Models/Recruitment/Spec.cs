namespace AscendedGuild.Models
{
	public class Spec
	{
		public int SpecId { get; set; }
		public string ImageUrl { get; set; }
		public string Name { get; set; }		
		public Demand Demand { get; set; }
	}
}