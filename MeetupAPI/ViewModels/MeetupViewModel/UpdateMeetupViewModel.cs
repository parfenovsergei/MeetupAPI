using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.ViewModels.MeetupViewModel
{
    public class UpdateMeetupViewModel
    {
        [Required(ErrorMessage = "Укажите название события")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Названия события должны быть от 3 до 50 символов")]
        public string MeetupName { get; set; }

        [Required(ErrorMessage = "Укажите описание события")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Описание события должно быть от 10 до 500 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Укажите дату и время события")]
        public DateTime MeetupDate { get; set; }

        [Required(ErrorMessage = "Укажите место события")]
        [MinLength(5, ErrorMessage = "Минимальная длина для места 5 символов")]
        public string MeetupLocation { get; set; }

        [Required(ErrorMessage = "Укажите email адрес спикера")]
        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        public string SpeakerEmail { get; set; }
    }
}
