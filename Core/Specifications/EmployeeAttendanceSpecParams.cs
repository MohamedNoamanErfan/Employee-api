using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class EmployeeAttendanceSpecParams
    {
        private const int MaxPageSize = 50;
        private int _pageIndex { get; set; } = 1;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = (value > 0) ? value : 1;
        }

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string? Sort { get; set; }
        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
