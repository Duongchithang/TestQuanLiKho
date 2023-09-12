using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;

namespace WebApplication1.Controller
{
    [Route("/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly quanlikhoContext context;

        public ProductController(quanlikhoContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            //[FromBody] Product product
            //context.Product.Add(product);
            //context.SaveChanges();
            //return new JsonResult(product);

            return Ok(new
            {
                message = "Ok"
            });
        }
        [HttpPost]
        public IActionResult GetProductById(string Id)
        {
            var Product = context.Product.FirstOrDefault(x => x.Id == Id);
            if (Product == null)
            {
                return new JsonResult(new
                {
                    message = "NotFound",
                    status = 400
                });
            }

            return Ok(new
            {
                data = Product,
                StatusCode = 200
            });
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                context.Product.Add(product);
                context.SaveChanges();
                return new JsonResult(new
                {
                    data = product,
                    status = 200
                });
            }


            return new JsonResult(new
            {
                message = "Invalid Data"
            });
        }
        [HttpPost]
        public IActionResult EditProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                var updateProduct = context.Product.FirstOrDefault(x => x.Id == product.Id);
                updateProduct.ProductName = product.ProductName;
                updateProduct.Id = product.Id;
                updateProduct.Price = product.Price;
                updateProduct.Description = product.Description;
                context.SaveChanges();
                return new JsonResult(new
                {
                    data = updateProduct,
                    status = 200
                });
            }
            return Ok(new
            {
                message = "Invalid Data"
            });
        }
        [HttpPost]
        public IActionResult DeleteProduct(string Id)
        {


            var removeProduct = context.Product.Find(Id);
            if (removeProduct != null)
            {
                context.Product.Remove(removeProduct);
                context.SaveChanges();
                return new JsonResult(new
                {
                    data = Id
                });
            }
            return new JsonResult(new { message = "ok" });
        }
    }
}
