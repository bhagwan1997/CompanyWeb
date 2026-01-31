using CompanyWeb.Models.CompanyDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CompanyWeb.Pages.EmployeeCounts
{
    public class IndexModel : PageModel
    {
        private readonly CompanyContext _context;

        public IndexModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<Row> Rows { get; set; } = new List<Row>();

        public class Row
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; } = "";
            public int EmployeeCount { get; set; }
        }

        public async Task OnGetAsync()
        {
            Rows = await _context.Employees
                .Where(e => e.DepartmentId != null)
                .GroupBy(e => e.DepartmentId)
                .Select(g => new
                {
                    DepartmentId = g.Key!.Value,
                    EmployeeCount = g.Count()
                })
                .Join(_context.Departments,
                    g => g.DepartmentId,
                    d => d.DepartmentId,
                    (g, d) => new Row
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName,
                        EmployeeCount = g.EmployeeCount
                    })
                .OrderBy(r => r.DepartmentId)
                .ToListAsync();
        }
    }
}
