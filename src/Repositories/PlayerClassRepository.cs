using System.Collections.Generic;

namespace AscendedGuild.Models
{
	public class PlayerClassRepository : IPlayerClassRepository
	{
		private readonly AppDbContext _appDbContext;

		public PlayerClassRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		
		public IEnumerable<PlayerClass> AllPlayerClasses => 
			_appDbContext.PlayerClasses;
	}
}