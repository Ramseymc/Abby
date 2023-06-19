using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class CategoryRepository :  Repository<Category>, ICategoryRepository
    {

        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
   
        public void Update(Category category)
        {
            var ObjFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            ObjFromDb.Name = category.Name;
            ObjFromDb.DisplayOrder = category.DisplayOrder;         
        }
    }
}
