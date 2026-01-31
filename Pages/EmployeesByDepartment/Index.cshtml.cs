using CompanyWeb.Models.CompanyDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CompanyWeb.Pages.EmployeesByDepartment
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
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; } = "";
        }

        public async Task OnGetAsync()
        {
            Rows = await _context.Employees
                .Include(e => e.Department)
                .Where(e => e.Department != null)
                .OrderBy(e => e.DepartmentId)
                .ThenBy(e => e.EmployeeId)
                .Select(e => new Row
                {
                    DepartmentId = e.Department!.DepartmentId,
                    DepartmentName = e.Department!.DepartmentName,
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.FirstName + " " + e.LastName
                })
                .ToListAsync();
        }
    }
}
