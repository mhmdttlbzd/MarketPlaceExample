using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Endpoint.Mvc.Models.Identity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [EmailAddress(ErrorMessage = "* آدرس ایمیل معتبر نمی باشد")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
