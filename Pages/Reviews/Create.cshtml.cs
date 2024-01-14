using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Reviews
{
    [Authorize(Roles = "User")]
    public class CreateModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public CreateModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "FullName");

            var Email = User.Identity.Name;
            var Pacients = _context.Pacient.Where(p => p.Email == Email);

            ViewData["PacientId"] = new SelectList(Pacients, "Id", "FullName");
                
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Review == null || Review == null)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
