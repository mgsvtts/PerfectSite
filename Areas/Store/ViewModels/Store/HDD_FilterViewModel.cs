﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.HDDManufacturers;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;
using Microsoft.AspNetCore.Mvc;

namespace PerfectSite.Areas.Store.ViewModels.Store.HDDs
{
    public class HDD_FilterViewModel : FilterViewModel
    {
        public HDD_FilterViewModel(List<HDDManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new HDDManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}