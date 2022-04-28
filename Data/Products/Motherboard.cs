﻿using PerfectSite.Data.Manufacturers.MotherboardManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class Motherboard : VirtualProduct
    {
        public MotherboardManufacturer Manufacturer { get; set; }
        public string Socket { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public string FormFactor { get; set; }
    }
}