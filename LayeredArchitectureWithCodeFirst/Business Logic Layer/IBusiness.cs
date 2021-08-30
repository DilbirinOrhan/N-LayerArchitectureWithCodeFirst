using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    interface IBusiness<TEntity>
    {
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Remove(TEntity item);
        TEntity Get(int id);

        List<TEntity> GetAll();
    }
}
