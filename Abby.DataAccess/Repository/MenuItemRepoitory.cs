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
    public class MenuItemRepository :  Repository<MenuItem>, IMenuItemRepository
    {

        private readonly ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
   
    

        public void Update(MenuItem obj)
        {
            var ObjFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
            ObjFromDb.Name = obj.Name;
            ObjFromDb.Description = obj.Description;
            ObjFromDb.Price = obj.Price;
            ObjFromDb.CategoryId = obj.CategoryId;
            ObjFromDb.FoodTypeId = obj.FoodTypeId;
            if(ObjFromDb.Image  != null)
            {
                ObjFromDb.Image = obj.Image;
            }
        }
    }
}
