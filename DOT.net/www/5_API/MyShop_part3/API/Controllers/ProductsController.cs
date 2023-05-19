using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // The unitOfWork replaces all import of the Repositories.
        private IUnitOfWork _unitOfWork;

        // No need to use the ShoppingContext, the UnitOfWork already does that.
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var orders = _unitOfWork.ProductRepository.All();
            return orders.ToList();
        }


        // GET: api/Product/{id}
        [HttpGet]
        public ActionResult<Product> GetProduct(int id)
        {
            var porduct = _unitOfWork.ProductRepository.Get(id);
            return porduct;
        }


        // POST: api/Products
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }
    }
}
