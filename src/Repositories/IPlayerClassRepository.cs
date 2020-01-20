using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public interface IPlayerClassRepository
	{
		IEnumerable<PlayerClass> AllPlayerClasses { get; }
	}
}