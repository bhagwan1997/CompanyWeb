using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly CompanyContext _context;

        public DetailsModel(CompanyContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; } = new Employee();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (employee == null) return NotFound();

            Employee = employee;
            return Page();
        }
    }
}
