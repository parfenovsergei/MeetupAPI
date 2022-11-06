using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.ViewModels.UserViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Введите email адрес")]
        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}
