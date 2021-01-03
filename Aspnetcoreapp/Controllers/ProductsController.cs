using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductLibrary;

namespace aspnetcoreapp.Controllers
{
    [Route("")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsProvider _provider = new ProductsProvider();

        [HttpGet ("/all")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try
            {
                return _provider.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during providing products, maybe DB is not fully initialized yet? " +
                                  $"Try again in a few minutes and if it doesn't help, check your docker-compose configuration.\n{e}");
                
                return new Product[0];
            }
        }


        [HttpGet("/{id}")]
        public ActionResult<Product> GetById(int id)
        {
            try
            {
                return _provider.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during providing products, maybe DB is not fully initialized yet? " +
                                  $"Try again in a few minutes and if it doesn't help, check your docker-compose configuration.\n{e}");

                return null;
            }
        }

        [HttpPost("/create")]
        public ActionResult<Product> Create([FromBody]Product product)
        {
            try
            {
                return _provider.Create(product);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during providing products, maybe DB is not fully initialized yet? " +
                                  $"Try again in a few minutes and if it doesn't help, check your docker-compose configuration.\n{e}");

                return null;
            }
        }

        [HttpPost("/modify/{id}")]
        public ActionResult<Product> Modify(int id, [FromBody]Product product)
        {
            try
            {
                return _provider.Modify(id, product);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during providing products, maybe DB is not fully initialized yet? " +
                                  $"Try again in a few minutes and if it doesn't help, check your docker-compose configuration.\n{e}");

                return null;
            }
        }

        [HttpPost("/delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return _provider.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during providing products, maybe DB is not fully initialized yet? " +
                                  $"Try again in a few minutes and if it doesn't help, check your docker-compose configuration.\n{e}");

                return null;
            }
        }
    }
}