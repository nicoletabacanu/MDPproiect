using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Migrations;
using proiect.Models;

namespace proiect.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public IndexModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Admin"))
            {
                if (_context.Programare != null)
                {
                    Programare = await _context.Programare
                    .Include(p => p.Doctor)
                    .Include(p => p.Pacient).ToListAsync();
                }
            }
            else
            {
                if (User.IsInRole("User"))
                {
                    var Email = User.Identity.Name;
                    Pacient Pacient = _context.Pacient.FirstOrDefault(p => p.Email == Email);

                    Programare = await _context.Programare
                       .Include(p => p.Doctor)
                       .Include(p => p.Pacient)
                       .Where(p => p.PacientId == Pacient.Id)
                       .ToListAsync();
                }
            }
        }
    }
}
