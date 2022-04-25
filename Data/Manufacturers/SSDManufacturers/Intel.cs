﻿using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.SSDManufacturers
{
    public class Intel : SSDManufacturer
    {
        public Intel()
        {
            Products = new List<SSD>();
        }
    }
}