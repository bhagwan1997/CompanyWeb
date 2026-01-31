using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly CompanyContext _context;

        public IndexModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get; set; } = new List<Department>();

        public async Task OnGetAsync()
        {
            Department = await _context.Departments
                .OrderBy(d => d.DepartmentId)
                .ToListAsync();
        }
    }
}
