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
    public class UserDashboard : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserDashboard(ApplicationDbContext context)
        {
            _context = context;
        }

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime JoinDate { get; set; }

        public List<DiaryEntry> DiaryEntries { get; set; }

        public User user { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {


            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            var id = HttpContext.Session.GetInt32("UserId");
            if (id == null)
            {
                return RedirectToPage("/LoginPage");
            }
            user = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);


            // Fetch user details (replace with actual user retrieval logic)
            UserName = user.FullName; // Fetch from database or user context
            UserEmail = user.Email; // Fetch from database or user context
            JoinDate = DateTime.Now; // Sample date for illustration

            // Fetch user's diary entries from the database
            // DiaryEntries = await _context.DiaryEntries.ToListAsync();
            DiaryEntries = await _context.DiaryEntries.Where(s => s.UserId == id).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostEditAsync(int DiaryId, string Title, string Content)
        {
            var entry = await _context.DiaryEntries.FindAsync(DiaryId);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Title = Title;
            entry.Content = Content;

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var entry = await _context.DiaryEntries.FindAsync(id);
            if (entry != null)
            {
                _context.DiaryEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Diary/UserDashboard");
        }
    }
}