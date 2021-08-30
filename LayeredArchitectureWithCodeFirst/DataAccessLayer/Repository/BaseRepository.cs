using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private NexumContext _nexumContext;
		public BaseRepository(NexumContext nexumContext)
		{
			_nexumContext = nexumContext;
		}
		public void Add(TEntity item)
		{
			_nexumContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Added;
		}

		public TEntity Get(int id)
		{
			return _nexumContext.Set<TEntity>().Find(id);
		}

		public List<TEntity> GetAll()
		{
			return _nexumContext.Set<TEntity>().ToList();
		}

		public void Remove(TEntity item)
		{
			_nexumContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Deleted;
		}

		public void Update(TEntity item)
		{
			_nexumContext.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
		}
	}
}
