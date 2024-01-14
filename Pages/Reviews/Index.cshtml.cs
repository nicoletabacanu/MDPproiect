using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly proiect.Data.proiectContext _context;

        public IndexModel(proiect.Data.proiectContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Review != null)
            {
                Review = await _context.Review
                .Include(r => r.Doctor)
                .Include(r => r.Pacient).ToListAsync();
            }
        }

        public bool isReviewByUser(Review review)
        {
            var Email = User.Identity.Name;
            Pacient Pacient = _context.Pacient.FirstOrDefault(p => p.Email == Email);

            if (Pacient == null)
            {
                return false;
            }

            return review.PacientId == Pacient.Id;


        }
    }
}
