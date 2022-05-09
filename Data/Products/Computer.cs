using PerfectSite.Data.ManufacturersComputerManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class Computer : VirtualProduct
    {
        public ComputerManufacturer? Manufacturer { get; set; }
        public Guid CPUId { get; set; }
        public CPU CPU { get; set; }
        public Guid? GPUId { get; set; }
        public GPU? GPU { get; set; }
        public Guid RAMId { get; set; }
        public RAM RAM { get; set; }
        public Guid MotherboardId { get; set; }
        public Motherboard Motherboard { get; set; }
        public Guid? HDDId { get; set; }
        public HDD? HDD { get; set; }
        public Guid? SSDId { get; set; }
        public SSD? SSD { get; set; }
        public Guid PowerSupplyId { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public Guid FrameId { get; set; }
        public ComputerFrame Frame { get; set; }
    }
}