using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> _products;

        public void OnGet()
        {
            ProductService prodService = new ProductService();

            _products = prodService.GetProducts();
        }

    }
}