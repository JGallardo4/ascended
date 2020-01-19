using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AscendedGuild.Models
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{			
		}

		public DbSet<PlayerClass> PlayerClasses { get; set; }
		public DbSet<Spec> Specs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed Specializations
			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 1,
				ImageUrl = "/images/dk-blood.jpg",
				Demand = Demand.Closed,
				Name = "Blood"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 2,
				ImageUrl = "/images/dk-frost.jpg",
				Demand = Demand.Closed,
				Name = "Frost"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 3,
				ImageUrl = "/images/dk-unholy.jpg",
				Demand = Demand.Closed,
				Name = "Unholy"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 4,
				ImageUrl = "/images/mage-arcane.jpg",
				Demand = Demand.Closed,
				Name = "Arcane"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 5,
				ImageUrl = "/images/mage-fire.jpg",
				Demand = Demand.Closed,
				Name = "Fire"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 6,
				ImageUrl = "/images/mage-frost.jpg",
				Demand = Demand.Closed,
				Name = "Frost"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 7,
				ImageUrl = "/images/rogue-assassination.jpg",
				Demand = Demand.Closed,
				Name = "Assassination"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 8,
				ImageUrl = "/images/rogue-outlaw.jpg",
				Demand = Demand.Closed,
				Name = "Outlaw"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 9,
				ImageUrl = "/images/rogue-subtlety.jpg",
				Demand = Demand.Closed,
				Name = "Subtlety"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 10,
				ImageUrl = "/images/dh-havoc.jpg",
				Demand = Demand.Closed,
				Name = "Havoc"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 11,
				ImageUrl = "/images/dh-vengeance.jpg",
				Demand = Demand.Closed,
				Name = "Vengeance"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 12,
				ImageUrl = "/images/monk-brewmaster.jpg",
				Demand = Demand.Closed,
				Name = "Brewmaster"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 13,
				ImageUrl = "/images/monk-mistweaver.jpg",
				Demand = Demand.Closed,
				Name = "Mistweaver"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 14,
				ImageUrl = "/images/monk-windwalker.jpg",
				Demand = Demand.Closed,
				Name = "Windwalker"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 15,
				ImageUrl = "/images/shaman-elemental.jpg",
				Demand = Demand.Closed,
				Name = "Elemental"
			});
			
			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 16,
				ImageUrl = "/images/shaman-enhancement.jpg",
				Demand = Demand.Closed,
				Name = "Enhancement"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 17,
				ImageUrl = "/images/shaman-restoration.jpg",
				Demand = Demand.Closed,
				Name = "Restoration"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 18,
				ImageUrl = "/images/druid-balance.jpg",
				Demand = Demand.Closed,
				Name = "Balance"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 19,
				ImageUrl = "/images/druid-feral.jpg",
				Demand = Demand.Closed,
				Name = "Feral"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 20,
				ImageUrl = "/images/druid-guardian.jpg",
				Demand = Demand.Closed,
				Name = "Guardian"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 21,
				ImageUrl = "/images/druid-restoration.jpg",
				Demand = Demand.Closed,
				Name = "Restoration"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 22,
				ImageUrl = "/images/paladin-holy.jpg",
				Demand = Demand.Closed,
				Name = "Holy"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 23,
				ImageUrl = "/images/paladin-protection.jpg",
				Demand = Demand.Closed,
				Name = "Protection"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 24,
				ImageUrl = "/images/paladin-retribution.jpg",
				Demand = Demand.Closed,
				Name = "Retribution"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 25,
				ImageUrl = "/images/warlock-affliction.jpg",
				Demand = Demand.Closed,
				Name = "Affliction"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 26,
				ImageUrl = "/images/warlock-demonology.jpg",
				Demand = Demand.Closed,
				Name = "Demonology"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 27,
				ImageUrl = "/images/warlock-destruction.jpg",
				Demand = Demand.Closed,
				Name = "Destruction"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 28,
				ImageUrl = "/images/hunter-bm.jpg",
				Demand = Demand.Closed,
				Name = "Beast Mastery"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 29,
				ImageUrl = "/images/hunter-marksmanship.jpg",
				Demand = Demand.Closed,
				Name = "Marksmanship"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 30,
				ImageUrl = "/images/hunter-survival.jpg",
				Demand = Demand.Closed,
				Name = "Survival"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 31,
				ImageUrl = "/images/priest-discipline.jpg",
				Demand = Demand.Closed,
				Name = "Discipline"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 32,
				ImageUrl = "/images/priest-holy.jpg",
				Demand = Demand.Closed,
				Name = "Holy"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 33,
				ImageUrl = "/images/priest-shadow.jpg",
				Demand = Demand.Closed,
				Name = "Shadow"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 34,
				ImageUrl = "/images/warrior-arms.jpg",
				Demand = Demand.Closed,
				Name = "Arms"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 35,
				ImageUrl = "/images/warrior-fury.jpg",
				Demand = Demand.Closed,
				Name = "Fury"
			});

			modelBuilder.Entity<Spec>().HasData(new Spec
			{
				SpecId = 36,
				ImageUrl = "/images/warrior-protection.jpg",
				Demand = Demand.Closed,
				Name = "Protection"
			});

			// Seed Player Classes
			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 1,
				ImageUrl = "/images/dk.png",
				Name = "Death Knight",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 2,
				ImageUrl = "/images/mage.png",
				Name = "Mage",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 3,
				ImageUrl = "/images/rogue.png",
				Name = "Rogue",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 4,
				ImageUrl = "/images/dh.png",
				Name = "Demon Hunter",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 5,
				ImageUrl = "/images/monk.png",
				Name = "Monk",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 6,
				ImageUrl = "/images/shaman.png",
				Name = "Shaman",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 7,
				ImageUrl = "/images/druid.png",
				Name = "Druid",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 8,
				ImageUrl = "/images/paladin.png",
				Name = "Paladin",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 9,
				ImageUrl = "/images/warlock.png",
				Name = "Warlock",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 10,
				ImageUrl = "/images/hunter.png",
				Name = "Hunter",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 11,
				ImageUrl = "/images/priest.png",
				Name = "Priest",
				Specs = new List<Spec>(),
			});

			modelBuilder.Entity<PlayerClass>().HasData(new PlayerClass
			{
				ClassId = 12,
				ImageUrl = "/images/warrior.png",
				Name = "Warrior",
				Specs = new List<Spec>(),
			});
		}
  }
}