using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Programari
{
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

            if (User.IsInRole("Admin"))
            {
                ViewData["PacientId"] = new SelectList(_context.Pacient, "Id", "FullName");
            }
            else
            {
                if (User.IsInRole("User"))
                {
                    var Email = User.Identity.Name;
                    var Pacients = _context.Pacient.Where(p => p.Email == Email);

                    ViewData["PacientId"] = new SelectList(Pacients, "Id", "FullName");
                }
            }

            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Programare == null || Programare == null)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
