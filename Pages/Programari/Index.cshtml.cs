using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
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
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                .Include(p => p.Doctor)
                .Include(p => p.Pacient).ToListAsync();
            }
        }
    }
}
