using Abby.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new {data = menuItemList});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id = id);

            _unitOfWork.MenuItem.Remove(objFromDb);
            _unitOfWork.Save();
            var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new { data = menuItemList });
        }
    }
}
 