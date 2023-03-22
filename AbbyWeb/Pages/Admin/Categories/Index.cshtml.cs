using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {

        private readonly ICategoryRepository _dbCategory;

        public IEnumerable<Category> Categories { get; set; }

        /// <summary>
        /// Dependancy inject the ApplicationDbContext file so that the db is connected
        /// </summary>
        /// <param name="db"></param>
        public IndexModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
        }

        public void OnGet()
        {
            Categories = _dbCategory.GetAll();
        }
    }
}
