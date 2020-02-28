using AscendedGuild.Models.About;
using AscendedGuild.Models.Recruitement;
using AscendedGuild.Models.Streams;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Data
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{			
		}

		public DbSet<PlayerClass> PlayerClasses { get; set; }
		public DbSet<Spec> Specs { get; set; }
		public DbSet<TwitchStreamer> TwitchStreamers { get; set; }
		public DbSet<TextBlock> TextBlocks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed player classes
			modelBuilder.Entity<PlayerClass>().HasData(
				new PlayerClass
				{
					PlayerClassId = 1,
					ImageUrl = "/images/class-icons/dk.png",
					Name = "Death Knight"			
				},

				new PlayerClass
				{
					PlayerClassId = 2,
					ImageUrl = "/images/class-icons/mage.png",
					Name = "Mage"			
				},

				new PlayerClass
				{
					PlayerClassId = 3,
					ImageUrl = "/images/class-icons/rogue.png",
					Name = "Rogue"		
				},

				new PlayerClass
				{
					PlayerClassId = 4,
					ImageUrl = "/images/class-icons/dh.png",
					Name = "Demon Hunter"				
				},

				new PlayerClass
				{
					PlayerClassId = 5,
					ImageUrl = "/images/class-icons/monk.png",
					Name = "Monk"			
				},

				new PlayerClass
				{
					PlayerClassId = 6,
					ImageUrl = "/images/class-icons/shaman.png",
					Name = "Shaman"				
				},

				new PlayerClass
				{
					PlayerClassId = 7,
					ImageUrl = "/images/class-icons/druid.png",
					Name = "Druid"			
				},

				new PlayerClass
				{
					PlayerClassId = 8,
					ImageUrl = "/images/class-icons/paladin.png",
					Name = "Paladin"
				},

				new PlayerClass
				{
					PlayerClassId = 9,
					ImageUrl = "/images/class-icons/warlock.png",
					Name = "Warlock"			
				},

				new PlayerClass
				{
					PlayerClassId = 10,
					ImageUrl = "/images/class-icons/hunter.png",
					Name = "Hunter"			
				},

				new PlayerClass
				{
					PlayerClassId = 11,
					ImageUrl = "/images/class-icons/priest.png",
					Name = "Priest"		
				},

				new PlayerClass
				{
					PlayerClassId = 12,
					ImageUrl = "/images/class-icons/warrior.png",
					Name = "Warrior"			
				}
			);

			// Seed Specializations
			modelBuilder.Entity<Spec>().HasData(
				new Spec() {
				PlayerClassId = 1,
				SpecId = 1,
				ImageUrl = "/images/class-icons/dk-blood.jpg",
				Demand = DemandEnum.CLOSED,
				Name = "Blood"
				},

				new Spec() {
				PlayerClassId = 1,
				SpecId = 2,
				ImageUrl = "/images/class-icons/dk-frost.jpg",
				Demand = DemandEnum.CLOSED,
				Name = "Frost"
				},
				
				new Spec()
				{
					PlayerClassId = 1,
					SpecId = 3,					
					ImageUrl = "/images/class-icons/dk-unholy.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Unholy"
				},
				
				new Spec()
				{
					PlayerClassId = 2,
					SpecId = 4,
					ImageUrl = "/images/class-icons/mage-arcane.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Arcane"
				},

				new Spec()
				{
					PlayerClassId = 2,
					SpecId = 5,
					ImageUrl = "/images/class-icons/mage-fire.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Fire"
				},

				new Spec()
				{
					PlayerClassId = 2,
					SpecId = 6,
					ImageUrl = "/images/class-icons/mage-frost.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Frost"
				},

				new Spec()
				{
					PlayerClassId = 3,
					SpecId = 7,
					ImageUrl = "/images/class-icons/rogue-assassination.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Assassination"
				},

				new Spec()
				{
					PlayerClassId = 3,
					SpecId = 8,
					ImageUrl = "/images/class-icons/rogue-outlaw.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Outlaw"
				},
				
				new Spec()
				{
					PlayerClassId = 3,
					SpecId = 9,
					ImageUrl = "/images/class-icons/rogue-subtlety.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Subtlety"
				},

				new Spec()
				{
					PlayerClassId = 4,
					SpecId = 10,
					ImageUrl = "/images/class-icons/dh-havoc.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Havoc"
				},

				new Spec()
				{
					PlayerClassId = 4,
					SpecId = 11,
					ImageUrl = "/images/class-icons/dh-vengeance.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Vengeance"
				},

				new Spec()
				{
					PlayerClassId = 5,
					SpecId = 12,
					ImageUrl = "/images/class-icons/monk-brewmaster.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Brewmaster"
				},

				new Spec()
				{
					PlayerClassId = 5,
					SpecId = 13,
					ImageUrl = "/images/class-icons/monk-mistweaver.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Mistweaver"
				},

				new Spec()
				{
					PlayerClassId = 5,
					SpecId = 14,
					ImageUrl = "/images/class-icons/monk-windwalker.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Windwalker"
				},

				new Spec()
				{
					PlayerClassId = 6,
					SpecId = 15,
					ImageUrl = "/images/class-icons/shaman-elemental.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Elemental"
				},
				
				new Spec()
				{
					PlayerClassId = 6,
					SpecId = 16,
					ImageUrl = "/images/class-icons/shaman-enhancement.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Enhancement"
				},

				new Spec()
				{
					PlayerClassId = 6,
					SpecId = 17,
					ImageUrl = "/images/class-icons/shaman-restoration.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Restoration"
				},

				new Spec()
				{
					PlayerClassId = 7,
					SpecId = 18,
					ImageUrl = "/images/class-icons/druid-balance.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Balance"
				},

				new Spec()
				{
					PlayerClassId = 7,
					SpecId = 19,
					ImageUrl = "/images/class-icons/druid-feral.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Feral"
				},
				
				new Spec()
				{
					PlayerClassId = 7,
					SpecId = 20,
					ImageUrl = "/images/class-icons/druid-guardian.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Guardian"
				},

				new Spec()
				{
					PlayerClassId = 7,
					SpecId = 21,
					ImageUrl = "/images/class-icons/druid-restoration.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Restoration"
				},

				new Spec()
				{
					PlayerClassId = 8,
					SpecId = 22,
					ImageUrl = "/images/class-icons/paladin-holy.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Holy"
				},

				new Spec()
				{
					PlayerClassId = 8,
					SpecId = 23,
					ImageUrl = "/images/class-icons/paladin-protection.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Protection"
				},

				new Spec()
				{
					PlayerClassId = 8,
					SpecId = 24,
					ImageUrl = "/images/class-icons/paladin-retribution.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Retribution"
				},

				new Spec()
				{
					PlayerClassId = 9,
					SpecId = 25,
					ImageUrl = "/images/class-icons/warlock-affliction.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Affliction"
				},

				new Spec()
				{
					PlayerClassId = 9,
					SpecId = 26,
					ImageUrl = "/images/class-icons/warlock-demonology.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Demonology"
				},

				new Spec()
				{
					PlayerClassId = 9,
					SpecId = 27,
					ImageUrl = "/images/class-icons/warlock-destruction.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Destruction"
				},

				new Spec()
				{
					PlayerClassId = 10,
					SpecId = 28,
					ImageUrl = "/images/class-icons/hunter-bm.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Beast Mastery"
				},

				new Spec()
				{
					PlayerClassId = 10,
					SpecId = 29,
					ImageUrl = "/images/class-icons/hunter-marksmanship.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Marksmanship"
				},

				new Spec()
				{
					PlayerClassId = 10,
					SpecId = 30,
					ImageUrl = "/images/class-icons/hunter-survival.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Survival"
				},

				new Spec()
				{
					PlayerClassId = 11,
					SpecId = 31,
					ImageUrl = "/images/class-icons/priest-discipline.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Discipline"
				},

				new Spec()
				{
					PlayerClassId = 11,
					SpecId = 32,
					ImageUrl = "/images/class-icons/priest-holy.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Holy"
				},

				new Spec()
				{
					PlayerClassId = 11,
					SpecId = 33,
					ImageUrl = "/images/class-icons/priest-shadow.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Shadow"
				},

				new Spec()
				{
					PlayerClassId = 12,
					SpecId = 34,
					ImageUrl = "/images/class-icons/warrior-arms.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Arms"
				},

				new Spec()
				{
					PlayerClassId = 12,
					SpecId = 35,
					ImageUrl = "/images/class-icons/warrior-fury.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Fury"
				},

				new Spec()
				{
					PlayerClassId = 12,
					SpecId = 36,
					ImageUrl = "/images/class-icons/warrior-protection.jpg",
					Demand = DemandEnum.CLOSED,
					Name = "Protection"
				}
			);			
		}
  }
}