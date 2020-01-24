using System;
using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public interface ISpecRepository
	{
		IEnumerable<Spec> AllSpecs { get; }

		void UpdateSpec(int specId, DemandEnum newDemand);
	}
}