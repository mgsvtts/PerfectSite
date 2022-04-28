﻿using System.ComponentModel.DataAnnotations;

namespace PerfectSite.ViewModels.Cabinet
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