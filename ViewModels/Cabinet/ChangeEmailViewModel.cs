using System.ComponentModel.DataAnnotations;

namespace PerfectSite.ViewModels.Cabinet
{
    public class ChangeEmailViewModel
    {
        public string Id { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный формат адреса")]
        public string OldEmail { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный формат адреса")]
        public string NewEmail { get; set; }
    }
}