using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
