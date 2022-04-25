using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Cabinet
{
    public class ChangeEmailViewModel
    {
        public string Id { get; set; }

        [EmailAddress]
        public string OldEmail { get; set; }

        [EmailAddress]
        public string NewEmail { get; set; }
    }
}