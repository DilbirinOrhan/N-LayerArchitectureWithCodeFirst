using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	interface IRepository<T>
	{
		void Add(T item);
		void Remove(T item);
		void Update(T item );

		List<T> GetAll();
		T Get(int id);

	}
}
