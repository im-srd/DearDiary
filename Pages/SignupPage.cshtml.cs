using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DearyDiary.Data;
using DearyDiary.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DearDiary.Pages
{
    public class SignupPage : PageModel
    {
        //---------------------------------------------------------------------------------
        private readonly ApplicationDbContext _context;

            public SignupPage(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User user {get; set;}

        //---------------------------------------------------------------------------------

        public void OnGet()
        {
        }

        public IActionResult OnPostSubmit(){
                var newUser = new User{
                    FullName = user.FullName,
                    Email = user.Email,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Username = user.Username,
                    Password = user.Password
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return RedirectToPage("/LoginPage");

        }
    }
}