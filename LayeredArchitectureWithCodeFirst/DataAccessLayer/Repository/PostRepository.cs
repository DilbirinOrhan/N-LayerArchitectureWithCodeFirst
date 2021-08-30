using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities1;

namespace DataAccessLayer.Repository
{
	public class PostRepository:BaseRepository<Post>
	{
		public PostRepository(NexumContext nexumContext):base(nexumContext)
		{

		}
	}
}
