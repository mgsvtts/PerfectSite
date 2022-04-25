namespace WebApplication1.ViewModels.PageSortFilter
{
    public enum SortState
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
        ManufacturerAsc,
        ManufacturerDesc,
        AmountAsc,
        AmountDesc,
        PopularityAsc,
        PopularityDesc
    }

    public class SortingViewModel
    {
        public SortState NameSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState ManufacturerSort { get; set; }
        public SortState AmountSort { get; set; }
        public SortState PopularitySort { get; set; }
        public SortState Current { get; private set; }

        public SortingViewModel(SortState sortState)
        {
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortState == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            ManufacturerSort = sortState == SortState.ManufacturerAsc ? SortState.ManufacturerDesc : SortState.ManufacturerAsc;
            AmountSort = sortState == SortState.AmountAsc ? SortState.AmountDesc : SortState.AmountAsc;
            PopularitySort = sortState == SortState.PopularityDesc ? SortState.PopularityAsc : SortState.PopularityDesc;
            Current = sortState;
        }
    }
}