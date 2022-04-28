namespace PerfectSite.Data.VirtualClasses
{
    public class VirtualManufacturer
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public List<VirtualProduct> Products { get; set; }
    }
}