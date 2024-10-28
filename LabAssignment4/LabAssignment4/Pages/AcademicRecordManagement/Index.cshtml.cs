using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAssignment4.DataAccess;

namespace LabAssignment4.Pages.AcademicRecordManagement
{
    public class IndexModel : PageModel
    {
        private readonly LabAssignment4.DataAccess.StudentrecordContext _context;

        public IndexModel(LabAssignment4.DataAccess.StudentrecordContext context)
        {
            _context = context;
        }

        public IList<AcademicRecord> AcademicRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AcademicRecord = await _context.AcademicRecords
                .Include(a => a.CourseCodeNavigation)
                .Include(a => a.Student).ToListAsync();
        }
    }
}
