using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    interface IProductRepository
    {
        IEnumerable<IniSet> GetAll();
        IniSet Get(int id);
        IniSet Add(IniSet item);
        void Remove(int id);
        bool Update(IniSet item);
    }
}
