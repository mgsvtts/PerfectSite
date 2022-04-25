using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.VirtualClasses;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store
{
    public class ControllerActions<T> where T : VirtualProduct
    {
        private IQueryable<T> _products;

        public ControllerActions(IQueryable<T> products)
        {
            _products = products;
        }

        public IQueryable<T> AddSort(SortState sortOrder = SortState.NameAsc)
        {
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    _products = _products.OrderByDescending(s => s.ModelName);
                    break;

                case SortState.PriceAsc:
                    _products = _products.OrderBy(s => s.Price);
                    break;

                case SortState.PriceDesc:
                    _products = _products.OrderByDescending(s => s.Price);
                    break;

                case SortState.ManufacturerAsc:
                    _products = _products.OrderBy(s => s.Manufacturer.Name);
                    break;

                case SortState.ManufacturerDesc:
                    _products = _products.OrderByDescending(s => s.Manufacturer.Name);
                    break;

                case SortState.AmountAsc:
                    _products = _products.OrderBy(s => s.Amount);
                    break;

                case SortState.AmountDesc:
                    _products = _products.OrderByDescending(s => s.Amount);
                    break;

                case SortState.PopularityAsc:
                    _products = _products.OrderBy(s => s.BoughtTimes);
                    break;

                case SortState.PopularityDesc:
                    _products = _products.OrderByDescending(s => s.BoughtTimes);
                    break;

                default:
                    _products = _products.OrderBy(s => s.ModelName);
                    break;
            }
            return _products;
        }

        public IQueryable<T> AddFilter(int? manufacturer, string name)
        {
            if (manufacturer != null && manufacturer != 0)
                _products = _products.Where(p => p.ManufacturerId == manufacturer);

            if (!String.IsNullOrEmpty(name))
                _products = _products.Where(p => p.ModelName.Contains(name));

            return _products;
        }

        public async Task<(int count, int page, List<T> items)> AddPagination(int page = 1)
        {
            int pageSize = PageViewModel.PageSize;

            var count = await _products.CountAsync();
            var items = await _products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (count, page, items);
        }
    }
}