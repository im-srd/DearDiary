using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DearDiary.Pages
{
    public class LoginPage : PageModel
    {
        private readonly ILogger<LoginPage> _logger;

        public LoginPage(ILogger<LoginPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}