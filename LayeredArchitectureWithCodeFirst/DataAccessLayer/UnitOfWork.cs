using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
	public class UnitOfWork
	{
		DbContextTransaction _transaction;
		NexumContext _nexumContext;

		public UnitOfWork()
		{
			_nexumContext = new NexumContext();
			_transaction = _nexumContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
		}
		private PostRepository _postRepository;

		public PostRepository PostRepository
		{
			get
			{
				if (_postRepository == null)
				{
					_postRepository = new PostRepository(_nexumContext);
				}
				return _postRepository;
			}
		}
		public bool ApplyChanges()
		{
			bool isSuccess = false;
			try
			{
				_nexumContext.SaveChanges();
				//_transaction.Commit();
				isSuccess = true;
			}
			catch (Exception e)
			{

				_transaction.Rollback();
				isSuccess = false;
			}
			finally
			{
				_transaction.Dispose();
			}
			return isSuccess;
		}
	}
}
