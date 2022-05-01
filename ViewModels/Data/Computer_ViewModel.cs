using PerfectSite.Data.VirtualClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSite.ViewModels.Data
{
    public class Computer_ViewModel : VirtualProduct
    {
        public string? ManufacturerName { get; set; }

        [Required(ErrorMessage ="Наличие процессора обязательно")]
        public string CPUName { get; set; }
       
        [Required(ErrorMessage = "Наличие оперативной памяти обязательно")]
        public string RAMName { get; set; }

        [Required(ErrorMessage = "Наличие материнской платы обязательно")]
        public string MotherboardName { get; set; }
       
        [Required(ErrorMessage = "Наличие блока питания обязательно")]
        public string PowerSupplyName { get; set; }

        [Required(ErrorMessage = "Наличие корпуса обязательно")]
        public string FrameName { get; set; }

        public string? HDDName { get; set; }
        public string? SSDName { get; set; }
        public string? GPUName { get; set; }

    }
}
