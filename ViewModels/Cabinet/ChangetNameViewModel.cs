using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Cabinet
{
    public class ChangeNameViewModel
    {
        public string Id { get; set; }

        public string ChangingLabel { get; set; }

        public string OldName { get; set; }

        [Required(ErrorMessage = "Заполните поле"),MaxLength(50, ErrorMessage = "Длина должна быть меньше 50")]
        public string NewName { get; set; }
    }
}