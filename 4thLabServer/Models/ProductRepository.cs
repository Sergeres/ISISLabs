using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<IniSet> products = new List<IniSet>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new IniSet { Name = "Height", Value = "720" });
            Add(new IniSet { Name = "Width", Value = "1280"});
            Add(new IniSet { Name = "Text", Value = "Harry Potter"});
        }

        public IEnumerable<IniSet> GetAll()
        {
            return products;
        }

        public IniSet Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IniSet Add(IniSet item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(IniSet item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}