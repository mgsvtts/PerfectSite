﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.PowerSupplyManufacturers;
using PerfectSite.ViewModels.PageSortFilter;

namespace PerfectSite.ViewModels.Store.PowerSupplies
{
    public class PowerSupply_FilterViewModel : FilterViewModel
    {
        public PowerSupply_FilterViewModel(List<PowerSupplyManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new PowerSupplyManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}