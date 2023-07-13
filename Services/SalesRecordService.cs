using DocumentFormat.OpenXml.Office2010.ExcelAc;
using SalesWebMVC2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SalesWebMVC2.Models;

namespace SalesWebMVC2.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVC2Context _context;

        public SalesRecordService(SalesWebMVC2Context context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                     .Include(x => x.Seller)
                     .Include(x => x.Seller.Department)
                     .OrderByDescending(x => x.Date)
                     .ToListAsync(); 

        }

        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                     .Include(x => x.Seller)
                     .Include(x => x.Seller.Department)
                     .OrderByDescending(x => x.Date)
                     .GroupBy(x => x.Seller.Department)
                     .ToListAsync();

        }
    }
}
