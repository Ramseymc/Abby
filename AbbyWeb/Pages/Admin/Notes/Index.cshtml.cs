using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Notes
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IEnumerable<Note> Notes { get; set; }

        /// <summary>
        /// Dependancy inject the ApplicationDbContext file so that the db is connected
        /// </summary>
        /// <param name="db"></param>
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Notes = _db.Note;
        }
    }
}
