using System;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Models
{
	[Owned]
	public class Spec
	{
		public int SpecId { get; set; }
		public string ImageUrl { get; set; }
		public string Name { get; set; }		
		public DemandEnum Demand { get; set; }
		public PlayerClass PlayerClass { get; set; }
		public int PlayerClassId { get; set; }
	}
}