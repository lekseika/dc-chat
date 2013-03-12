using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaticMvc.Controllers
{
    public class ChatController : Controller
    {
        public class MessageBody
        {
            public string UserName { get; set; }
            public string Message { get; set; }
            public DateTime Time { get; set; }
        }
        private static List<MessageBody> messages = new List<MessageBody>();

        //
        // GET: /Chat/
        
        public ActionResult Index()
        {
            ViewBag.Messages = messages;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            Debug.Write(collection);
            return View();
        }
        //
        // GET: /Chat/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        ////
        //// GET: /Chat/Create

        public ActionResult Create()
        {
            return View("Index");
        }

        //
        // POST: /Chat/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Debug.Write(collection);
            try
            {
                // TODO: Add insert logic here
                messages.Add(new MessageBody{ 
                    UserName = collection["userName"]
                    , Message = collection["message"]
                    ,Time = DateTime.Now
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        //
        // GET: /Chat/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Chat/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Chat/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Chat/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Debug.Write(collection);
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
