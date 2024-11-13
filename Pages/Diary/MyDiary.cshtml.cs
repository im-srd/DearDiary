using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DearyDiary.Data;
using DearyDiary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DearDiary.Pages.Diary
{
    public class MyDiary : PageModel
    {
       private readonly ApplicationDbContext _context;

        public MyDiary(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiaryEntry NewEntry { get; set; }

        // [BindProperty]
        // public User user { get; set; }

        public List<DiaryEntry> Entries { get; set; }

        public async Task OnGetAsync()
        {
            Entries = await _context.DiaryEntries.ToListAsync();
            
            // var id = HttpContext.Session.GetInt32("UserId");
            // user = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
            // System.Console.WriteLine(id);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            var id = HttpContext.Session.GetInt32("UserId");
            if (!ModelState.IsValid)
            {
                return Page();
            }


            NewEntry.DateCreated = DateTime.Now;
            NewEntry.UserId = Convert.ToInt32(id);
            _context.DiaryEntries.Add(NewEntry);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Diary/UserDashboard");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var entry = await _context.DiaryEntries.FindAsync(id);

            if (entry != null)
            {
                _context.DiaryEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Diary/MyDiary");
        }
    }
}