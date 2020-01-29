using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Models
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{			
		}

		public DbSet<PlayerClass> PlayerClasses { get; set; }
		public DbSet<Spec> Specs { get; set; }
		public DbSet<TwitchStreamer> TwitchStreamers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed Player Classes
			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 1,
				ImageUrl = "/images/class-icons/dk.png",
				Name = "Death Knight"			
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 2,
				ImageUrl = "/images/class-icons/mage.png",
				Name = "Mage"			
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 3,
				ImageUrl = "/images/class-icons/rogue.png",
				Name = "Rogue"		
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 4,
				ImageUrl = "/images/class-icons/dh.png",
				Name = "Demon Hunter"				
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 5,
				ImageUrl = "/images/class-icons/monk.png",
				Name = "Monk"			
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 6,
				ImageUrl = "/images/class-icons/shaman.png",
				Name = "Shaman"				
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 7,
				ImageUrl = "/images/class-icons/druid.png",
				Name = "Druid"			
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 8,
				ImageUrl = "/images/class-icons/paladin.png",
				Name = "Paladin"
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 9,
				ImageUrl = "/images/class-icons/warlock.png",
				Name = "Warlock"			
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 10,
				ImageUrl = "/images/class-icons/hunter.png",
				Name = "Hunter"			
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 11,
				ImageUrl = "/images/class-icons/priest.png",
				Name = "Priest"		
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				Id = 12,
				ImageUrl = "/images/class-icons/warrior.png",
				Name = "Warrior"			
			});

			// Seed Specializations
			modelBuilder.Entity<PlayerClass>().OwnsMany(c => c.Specs).HasData(
				new {
				PlayerClassId = 1,
				Id = 1,
				ImageUrl = "/images/class-icons/dk-blood.jpg",
				Demand = DemandEnum.Closed,
				Name = "Blood"
				},

				new {
				PlayerClassId = 1,
				Id = 2,
				ImageUrl = "/images/class-icons/dk-frost.jpg",
				Demand = DemandEnum.Closed,
				Name = "Frost"
				},
				
				new
				{
					PlayerClassId = 1,
					Id = 3,					
					ImageUrl = "/images/class-icons/dk-unholy.jpg",
					Demand = DemandEnum.Closed,
					Name = "Unholy"
				},
				
				new
				{
					PlayerClassId = 2,
					Id = 4,
					ImageUrl = "/images/class-icons/mage-arcane.jpg",
					Demand = DemandEnum.Closed,
					Name = "Arcane"
				},

				new
				{
					PlayerClassId = 2,
					Id = 5,
					ImageUrl = "/images/class-icons/mage-fire.jpg",
					Demand = DemandEnum.Closed,
					Name = "Fire"
				},

				new
				{
					PlayerClassId = 2,
					Id = 6,
					ImageUrl = "/images/class-icons/mage-frost.jpg",
					Demand = DemandEnum.Closed,
					Name = "Frost"
				},

				new
				{
					PlayerClassId = 3,
					Id = 7,
					ImageUrl = "/images/class-icons/rogue-assassination.jpg",
					Demand = DemandEnum.Closed,
					Name = "Assassination"
				},

				new
				{
					PlayerClassId = 3,
					Id = 8,
					ImageUrl = "/images/class-icons/rogue-outlaw.jpg",
					Demand = DemandEnum.Closed,
					Name = "Outlaw"
				},
				
				new
				{
					PlayerClassId = 3,
					Id = 9,
					ImageUrl = "/images/class-icons/rogue-subtlety.jpg",
					Demand = DemandEnum.Closed,
					Name = "Subtlety"
				},

				new
				{
					PlayerClassId = 4,
					Id = 10,
					ImageUrl = "/images/class-icons/dh-havoc.jpg",
					Demand = DemandEnum.Closed,
					Name = "Havoc"
				},

				new
				{
					PlayerClassId = 4,
					Id = 11,
					ImageUrl = "/images/class-icons/dh-vengeance.jpg",
					Demand = DemandEnum.Closed,
					Name = "Vengeance"
				},

				new
				{
					PlayerClassId = 5,
					Id = 12,
					ImageUrl = "/images/class-icons/monk-brewmaster.jpg",
					Demand = DemandEnum.Closed,
					Name = "Brewmaster"
				},

				new
				{
					PlayerClassId = 5,
					Id = 13,
					ImageUrl = "/images/class-icons/monk-mistweaver.jpg",
					Demand = DemandEnum.Closed,
					Name = "Mistweaver"
				},

				new
				{
					PlayerClassId = 5,
					Id = 14,
					ImageUrl = "/images/class-icons/monk-windwalker.jpg",
					Demand = DemandEnum.Closed,
					Name = "Windwalker"
				},

				new
				{
					PlayerClassId = 6,
					Id = 15,
					ImageUrl = "/images/class-icons/shaman-elemental.jpg",
					Demand = DemandEnum.Closed,
					Name = "Elemental"
				},
				
				new
				{
					PlayerClassId = 6,
					Id = 16,
					ImageUrl = "/images/class-icons/shaman-enhancement.jpg",
					Demand = DemandEnum.Closed,
					Name = "Enhancement"
				},

				new
				{
					PlayerClassId = 6,
					Id = 17,
					ImageUrl = "/images/class-icons/shaman-restoration.jpg",
					Demand = DemandEnum.Closed,
					Name = "Restoration"
				},

				new
				{
					PlayerClassId = 7,
					Id = 18,
					ImageUrl = "/images/class-icons/druid-balance.jpg",
					Demand = DemandEnum.Closed,
					Name = "Balance"
				},

				new
				{
					PlayerClassId = 7,
					Id = 19,
					ImageUrl = "/images/class-icons/druid-feral.jpg",
					Demand = DemandEnum.Closed,
					Name = "Feral"
				},
				
				new
				{
					PlayerClassId = 7,
					Id = 20,
					ImageUrl = "/images/class-icons/druid-guardian.jpg",
					Demand = DemandEnum.Closed,
					Name = "Guardian"
				},

				new
				{
					PlayerClassId = 7,
					Id = 21,
					ImageUrl = "/images/class-icons/druid-restoration.jpg",
					Demand = DemandEnum.Closed,
					Name = "Restoration"
				},

				new
				{
					PlayerClassId = 8,
					Id = 22,
					ImageUrl = "/images/class-icons/paladin-holy.jpg",
					Demand = DemandEnum.Closed,
					Name = "Holy"
				},

				new
				{
					PlayerClassId = 8,
					Id = 23,
					ImageUrl = "/images/class-icons/paladin-protection.jpg",
					Demand = DemandEnum.Closed,
					Name = "Protection"
				},

				new
				{
					PlayerClassId = 8,
					Id = 24,
					ImageUrl = "/images/class-icons/paladin-retribution.jpg",
					Demand = DemandEnum.Closed,
					Name = "Retribution"
				},

				new
				{
					PlayerClassId = 9,
					Id = 25,
					ImageUrl = "/images/class-icons/warlock-affliction.jpg",
					Demand = DemandEnum.Closed,
					Name = "Affliction"
				},

				new
				{
					PlayerClassId = 9,
					Id = 26,
					ImageUrl = "/images/class-icons/warlock-demonology.jpg",
					Demand = DemandEnum.Closed,
					Name = "Demonology"
				},

				new
				{
					PlayerClassId = 9,
					Id = 27,
					ImageUrl = "/images/class-icons/warlock-destruction.jpg",
					Demand = DemandEnum.Closed,
					Name = "Destruction"
				},

				new
				{
					PlayerClassId = 10,
					Id = 28,
					ImageUrl = "/images/class-icons/hunter-bm.jpg",
					Demand = DemandEnum.Closed,
					Name = "Beast Mastery"
				},

				new
				{
					PlayerClassId = 10,
					Id = 29,
					ImageUrl = "/images/class-icons/hunter-marksmanship.jpg",
					Demand = DemandEnum.Closed,
					Name = "Marksmanship"
				},

				new
				{
					PlayerClassId = 10,
					Id = 30,
					ImageUrl = "/images/class-icons/hunter-survival.jpg",
					Demand = DemandEnum.Closed,
					Name = "Survival"
				},

				new
				{
					PlayerClassId = 11,
					Id = 31,
					ImageUrl = "/images/class-icons/priest-discipline.jpg",
					Demand = DemandEnum.Closed,
					Name = "Discipline"
				},

				new
				{
					PlayerClassId = 11,
					Id = 32,
					ImageUrl = "/images/class-icons/priest-holy.jpg",
					Demand = DemandEnum.Closed,
					Name = "Holy"
				},

				new
				{
					PlayerClassId = 11,
					Id = 33,
					ImageUrl = "/images/class-icons/priest-shadow.jpg",
					Demand = DemandEnum.Closed,
					Name = "Shadow"
				},

				new
				{
					PlayerClassId = 12,
					Id = 34,
					ImageUrl = "/images/class-icons/warrior-arms.jpg",
					Demand = DemandEnum.Closed,
					Name = "Arms"
				},

				new
				{
					PlayerClassId = 12,
					Id = 35,
					ImageUrl = "/images/class-icons/warrior-fury.jpg",
					Demand = DemandEnum.Closed,
					Name = "Fury"
				},

				new
				{
					PlayerClassId = 12,
					Id = 36,
					ImageUrl = "/images/class-icons/warrior-protection.jpg",
					Demand = DemandEnum.Closed,
					Name = "Protection"
				}
			);			
		}
  }
}