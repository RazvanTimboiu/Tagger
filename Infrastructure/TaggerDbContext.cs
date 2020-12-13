using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Interfaces;

namespace Persistence
{
    public class TaggerDbContext : DbContext, ITaggerDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<Dataset> DataSets { get; set; }
        public DbSet<Sample> Samples { get; set; }


        public TaggerDbContext(DbContextOptions<TaggerDbContext> options)
                : base(options)
        {
          
        }

		private string ComputeChoicesString(Dictionary<Class, int> d)
        {
			string result = "";
            
			foreach (var entry in d)
            {
				result += entry.Key.Id + "~" + entry.Value + "|";
            }

			result.Remove(result.Length - 1);

			return result;
        }

		private Dictionary<Class, int> ComputeChoicesMap(string choices)
		{
			Dictionary<Class, int> result = new Dictionary<Class, int>();

			foreach(var pair in choices.Split('|'))
            {
				var split = pair.Split('~');
				var klass = Classes.Find(int.Parse(split[0]));

				result.Add(klass, int.Parse(split[1]));
            }

			return result;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ 

			modelBuilder.Entity<Sample>()
				.Property(s => s.Choices)
				.HasConversion(v => ComputeChoicesString(v), v => ComputeChoicesMap(v));

			modelBuilder.Entity<Data>()
				.HasOne(d => d.Sample)
				.WithOne(s => s.Data)
				.HasForeignKey<Data>(d => d.SampleId);

			modelBuilder.Entity<Dataset>()
				.HasMany(ds => ds.Samples)
				.WithOne()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Dataset>()
				.HasMany(ds => ds.Classes)
				.WithOne()
				.OnDelete(DeleteBehavior.Cascade);

		}

	}
}
