using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace RazorSite.Pages.BookList
{
    public class EditBookModel : PageModel
    {
        private readonly BookContext _context;

        public EditBookModel(BookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = await _context.Books.FindAsync(Book.Id);
                bookFromDb.Author = Book.Author;
                bookFromDb.Name = Book.Name;
                bookFromDb.Description = Book.Description;
                bookFromDb.ISBN = Book.ISBN;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}