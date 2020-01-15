using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Models;

namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<IniSet> GetAllProducts()
        {
            return repository.GetAll();
        }

        public IniSet GetProduct(int id)
        {
            IniSet item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<IniSet> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Value, category, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProduct(IniSet item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<IniSet>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(int id, IniSet product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            repository.Remove(id);
        }
    }
}
