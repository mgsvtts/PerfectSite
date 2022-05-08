using Microsoft.AspNetCore.Mvc;
using PerfectSite.Areas.Store.ViewModels.Data;
using PerfectSite.Data.Products;

namespace PerfectSite.CustomUtilities
{
    public static class ComputerValidation
    {
        public static void Validate(CPU cpu, GPU? gpu, RAM ram, Motherboard motherboard, PowerSupply powerSupply, ComputerFrame frame, SSD? ssd, HDD? hdd, Controller controller, Computer_ViewModel model)
        {
            if (cpu == null)
            {
                controller.ModelState.AddModelError("CPUName", "Данный процессор не существует в базе данных, добавьте его перед использованием");
            }

            if (ram == null)
            {
                controller.ModelState.AddModelError("RAMName", "Данная оперативная память не существует в базе данных, добавьте её перед использованием");
            }

            if (motherboard == null)
            {
                controller.ModelState.AddModelError("MotherboardName", "Данная материнская плата не существует в базе данных, добавьте её перед использованием");
            }

            if (powerSupply == null)
            {
                controller.ModelState.AddModelError("PowerSupplyName", "Данный блок питания не существует в базе данных, добавьте его перед использованием");
            }

            if (frame == null)
            {
                controller.ModelState.AddModelError("FrameName", "Данный корпус не существует в базе данных, добавьте его перед использованием");
            }
            if (model.GPUName != null && gpu == null)
            {
                controller.ModelState.AddModelError("GPUName", "Данная видеокарта не существует в базе данных, добавьте её перед использованием");
            }

            if (model.HDDName != null && hdd == null)
            {
                controller.ModelState.AddModelError("HDDName", "Данный HDD не существует в базе данных, добавьте его перед использованием");
            }

            if (model.SSDName != null && ssd == null)
            {
                controller.ModelState.AddModelError("SSDName", "Данный SSD не существует в базе данных, добавьте его перед использованием");
            }
        }
    }
}