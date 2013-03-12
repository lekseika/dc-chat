using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StaticMvc.Controllers
{
    public class ChatController : Controller
    {
        public class ChatMessage
        {
            public DateTime Time { get; set; }
            public string Message { get; set; }
            public string UserName { get; set; }
        }

        public static List<ChatMessage> data = new List<ChatMessage>(); 
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            ViewBag.Messages = data;
            return View();
        }

        [ChildActionOnly]
        public ActionResult Messages()
        {
 
            return PartialView("_Messages",data.ToArray());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        //[ChildActionOnly]
        public ActionResult AddMessage(string sender,string message)
        {
           // Debug.WriteLine(message.ToString());
            if (!string.IsNullOrEmpty(sender) &&
                !string.IsNullOrEmpty(message))
            {
                //return new HttpStatusCodeResult(HttpStatusCode.OK);
                data.Add(new ChatMessage
                {
                    Message = message,
                    Time = DateTime.Now,
                    UserName = sender
                });
                return PartialView("_Messages",data);
            }
            throw new HttpException("Invalid data");
        }
        //
        // GET: /Chat/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Chat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chat/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
