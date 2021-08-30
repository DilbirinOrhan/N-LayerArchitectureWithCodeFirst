using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities1;

namespace DataAccessLayer.Mapping
{
	public class PostMap: EntityTypeConfiguration<Post>
	{
		public PostMap() 
		{
            HasKey(c => c.Id)
                    .Property(x => x.Id)
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Title).HasMaxLength(200).IsRequired();
			Property(c => c.Body).HasMaxLength(1000).IsRequired();


		}
	}
}
