using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities1;

namespace Business_Logic_Layer
{
	public class PostBusiness : IBusiness<Post>
	{
		UnitOfWork _unitOfWork;
		public PostBusiness()
		{
			_unitOfWork = new UnitOfWork();
		}
		public bool Add(Post item)
		{
			_unitOfWork.PostRepository.Add(item);
			return _unitOfWork.ApplyChanges();
		}

		public Post Get(int id)
		{
			return _unitOfWork.PostRepository.Get(id);
		}

		public List<Post> GetAll()
		{
			return _unitOfWork.PostRepository.GetAll();
		}

		public bool Remove(Post item)
		{
			_unitOfWork.PostRepository.Remove(item);
			return _unitOfWork.ApplyChanges();
		}

		public bool Update(Post item)
		{
			_unitOfWork.PostRepository.Update(item);
			return _unitOfWork.ApplyChanges();
		}
	}
}
