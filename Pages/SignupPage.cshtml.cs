using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DearDiary.Pages
{
    public class SignupPage : PageModel
    {
        private readonly ILogger<SignupPage> _logger;

        public SignupPage(ILogger<SignupPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}