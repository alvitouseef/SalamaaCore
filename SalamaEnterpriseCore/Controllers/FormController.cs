using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalamaEnterpriseCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalamaEnterpriseCore.Controllers
{
    public class FormController : Controller
    {
        FormFields formFld = new FormFields();
        public FormController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult CarDetails()
        {
            return View();
        }

        public ActionResult CarInformation()
        {
            return View();
        }

        [HttpPost]
        public JsonResult dropDownFiller(string key, string param)
        {
            try
            {
                
                return Json(formFld.dropDownFiller(key, param));
            }
            catch (Exception ex)
            {
                return Json("Error in " + ex.Message.ToString());
            }
        }

    }
}
