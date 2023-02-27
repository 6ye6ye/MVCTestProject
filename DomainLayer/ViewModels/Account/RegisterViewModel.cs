using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Длина логина должна быть от 5 до 25 символов")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Длина пароля должна быть от 5 до 25 символов")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string PasswordConfirm { get; set; }

    }
}
