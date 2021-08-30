using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Mapping;
using Entities1;

namespace DataAccessLayer
{
    public class NexumContext: DbContext
	{

		public NexumContext():base("Nexum")
		{

		}
		public virtual  DbSet<Post> Posts { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new PostMap());
		}
	}
}
