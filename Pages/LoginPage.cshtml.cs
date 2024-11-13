using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DearDiary.Models;
using DearyDiary.Data;
using DearyDiary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DearDiary.Pages
{
    public class LoginPage : PageModel
    {
        private readonly ApplicationDbContext _context;

            public LoginPage(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginModelClass user {get; set;}



        public void OnGet()
        {
        }

        public IActionResult OnPostSubmit(){
            if(!ModelState.IsValid){
                return Page();
            }
            else{
                var Data = _context.Users.SingleOrDefault(u => u.Username == user.Username);

                if(Data != null){
                    if (user.Username == Data.Username && user.Password == Data.Password){
                        //Logic to go to Diary wala page
                        HttpContext.Session.SetInt32("UserId",Data.Id); // Session set kr rhe hai, Id ka variable store kr rhe hai
                        return RedirectToPage("/Diary/UserDashboard");
                        
                    }
                    else{
                        return Page();
                    }
                }
                return Page();
            }
        }
    }
}