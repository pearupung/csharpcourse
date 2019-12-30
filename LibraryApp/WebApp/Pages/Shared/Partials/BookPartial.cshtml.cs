using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp
{
    public class BookPartialModel : PageModel
    {
        public Book Book { get; set; }
    }
}