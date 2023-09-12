using Microsoft.AspNetCore.Mvc.RazorPages;

using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly quanlikhoContext context;
        public List<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, quanlikhoContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public void OnGet()
        {
            Products = context.Product.ToList();

        }
        //public IActionResult OnPostCreate([FromBody] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Product.Add(product);
        //        context.SaveChanges();
        //        return new JsonResult(product);
        //    }
        //    return new JsonResult("Invalid data");
        //}
        //public IActionResult OnPostEdit([FromBody] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Product.Update(product);
        //        context.SaveChanges();
        //        return new JsonResult(product);
        //    }
        //    return new JsonResult("Invalid data");
        //}

        //public IActionResult OnPostDelete(string id)
        //{
        //    var removeProduct = context.Product.Find(id);
        //    if (removeProduct != null)
        //    {
        //        context.Product.Remove(removeProduct);
        //        context.SaveChanges();
        //        return new JsonResult(id);
        //    }
        //    return new JsonResult("Not found");
        //}
    }
}