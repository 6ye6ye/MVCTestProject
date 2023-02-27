using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels.Account;

public class LoginViewModel
{
    [Display(Name = "Логин")]
    [Required(ErrorMessage = "Необходимо ввести логин")]
    public string? Username { get; set; }

    [Display(Name = "Пароль")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Необходимо ввести пароль")]
    public string? Password { get; set; }
}