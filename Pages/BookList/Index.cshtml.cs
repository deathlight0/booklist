using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSite.Pages.BookList
{
    public class IndexModel : PageModel
    {

        private readonly BookContext _context;

        public IndexModel(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Book { get; set; }


        public void OnGet()
        {
            Book = _context.Books.ToList();
        }
    }
}