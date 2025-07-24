using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OTP.Services;

namespace OTP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PaswordUtils paswordUtils = new PaswordUtils();
            string generatedPassword = paswordUtils.GeneratePassword();

            HttpContext.Session.SetString("Password", generatedPassword);
            HttpContext.Session.SetString("GeneratedTime", DateTime.Now.ToString());

            ViewData["GeneratedPassword"] = generatedPassword;
        }

        public void OnPost(string UserEntry)
        {
            string storedPassword = HttpContext.Session.GetString("Password");
            string storedDate = HttpContext.Session.GetString("GeneratedTime");

            if (!DateTime.TryParse(storedDate, out DateTime generatedTime))
            {
                ViewData["CheckResult"] = "زمان تولید رمز نامعتبر است.";
                return;
            }


            if (string.IsNullOrEmpty(UserEntry))
            {
                ViewData["CheckResult"] = "لطفاً رمز را وارد کنید.";
            }
            else if (DateTime.Now > generatedTime.AddSeconds(60))
            {
                ViewData["CheckResult"] = "مدت اعتبار رمز به پایان رسیده.";
            }
            else if (UserEntry != storedPassword)
            {
                ViewData["CheckResult"] = "رمز وارد شده نادرست است.";
            }
            else
            {
                ViewData["CheckResult"] = "ورود موفقیت‌آمیز 🎉";
            }
        }

    }
}
