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
    public class DeleteModel : PageModel
    {
        private readonly LabAssignment4.DataAccess.StudentrecordContext _context;

        public DeleteModel(LabAssignment4.DataAccess.StudentrecordContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AcademicRecord AcademicRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicrecord = await _context.AcademicRecords.FirstOrDefaultAsync(m => m.StudentId == id);

            if (academicrecord == null)
            {
                return NotFound();
            }
            else
            {
                AcademicRecord = academicrecord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicrecord = await _context.AcademicRecords.FindAsync(id);
            if (academicrecord != null)
            {
                AcademicRecord = academicrecord;
                _context.AcademicRecords.Remove(AcademicRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
