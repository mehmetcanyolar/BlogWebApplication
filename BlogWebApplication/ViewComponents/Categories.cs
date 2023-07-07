using Microsoft.AspNetCore.Mvc;

namespace BlogWebApplication.ViewComponents
{
    public class Categories : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BL.CategoryManager categoryManger = new BL.CategoryManager();
            return View(categoryManger.GetAll());
        }
    }
}
