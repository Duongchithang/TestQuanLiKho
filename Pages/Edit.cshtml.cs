using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        public string Id { get; private set; }
        private readonly IHttpContextAccessor httpContextAccessor;

        public EditModel(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void OnGet(string id)
        {
            Id = id;
        }
    }
}
