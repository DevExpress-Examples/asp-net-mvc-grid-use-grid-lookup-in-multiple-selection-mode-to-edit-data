using Ex_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GridViewPartial()
        {
            var model = DataProvider.GetGridData();
            return PartialView(model);
        }
        public ActionResult GridLookupPartial(int? CurrentID)
        {
            ViewData["Tags"] = DataProvider.GetTags();
            GridDataItem model = new GridDataItem() { ID = -1, TagIDs = new int[0] };
            if (CurrentID > -1)
            {
                model = DataProvider.GetGridData().Where(item => item.ID == CurrentID).FirstOrDefault();
            }
          
            return PartialView(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUpdatePartial(GridDataItem item)
        {
            var model = DataProvider.GetGridData();
            if (ModelState.IsValid)
            {
                try
                {
                    DataProvider.UpdateGrid(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewInsertPartial(GridDataItem item)
        {
            var model = DataProvider.GetGridData();
            if (ModelState.IsValid)
            {
                try
                {
                    DataProvider.InsertGrid(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewDeletePartial(System.Int32 ID)
        {
            var model = DataProvider.GetGridData();

            if (ID >= 0)
            {
                try
                {
                    DataProvider.DeleteGrid(model.Where(x => x.ID == ID).FirstOrDefault());
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("GridViewPartial", model);
        }
    }
}
