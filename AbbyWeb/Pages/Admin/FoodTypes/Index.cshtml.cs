using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IEnumerable<Abby.Models.FoodType> FoodTypes { get; set; }

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
            FoodTypes = _db.FoodType;
        }
    }
}
