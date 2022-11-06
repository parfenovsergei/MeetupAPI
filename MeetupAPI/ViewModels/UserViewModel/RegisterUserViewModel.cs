using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.ViewModels.UserViewModel
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Укажите email адрес")]
        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Задайте пароль")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов")]
        public string Password { get; set; }
    }
}
