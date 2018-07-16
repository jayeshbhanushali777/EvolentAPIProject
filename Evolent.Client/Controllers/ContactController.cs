using Evolent.Client.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evolent.Client.Controllers
{
    public class ContactController : Controller
    {
        ContactContext contactContext = new ContactContext();

        public ActionResult Index()
        {
            ViewBag.contactList = contactContext.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ContactEntity entity)
        {
            if (ModelState.IsValid)
            {
                contactContext.Create(entity.contact);
                return RedirectToAction("Index");
            }

            return View(entity);

        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ContactEntity contactEntity = new ContactEntity();
                contactEntity.contact = contactContext.Get(id);
                return View("Edit", contactEntity);
            }
        }

        [HttpPost]
        public ActionResult Edit(ContactEntity entity)
        {
            if (ModelState.IsValid)
            {
                contactContext.Edit(entity.contact);
                return RedirectToAction("Index");
            }

            return View(entity); 
        }

        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                contactContext.Delete(id);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
	}
}