using System;
using System.Collections.Generic;
using System.Linq;

namespace AscendedGuild.Models
{
	public class SpecRepository : ISpecRepository
	{		
		private readonly AppDbContext _appDbContext;

		public SpecRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<Spec> AllSpecs => _appDbContext.Specs;

		public void UpdateSpec(int specId, DemandEnum newDemand)
		{
			var spec = _appDbContext.Specs.SingleOrDefault(s => s.Id == specId);

			if (spec != null && spec.Demand != newDemand)
			{
				spec.Demand = newDemand;
			}

			_appDbContext.SaveChanges();
		}
	}
}