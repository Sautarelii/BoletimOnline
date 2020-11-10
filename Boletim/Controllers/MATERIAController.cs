using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boletim;
using Boletim.Models;

namespace Boletim.Controllers
{
    public class MATERIAController : Controller
    {
        private BoletimOnline2Entities7 db = new BoletimOnline2Entities7();

        // GET: MATERIA
        public ActionResult Index()
        {
            return View(db.MATERIA.ToList());
        }

        // GET: MATERIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return HttpNotFound();
            }
            return View(mATERIA);
        }

        // GET: MATERIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MATERIA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_MATERIA,NOME")] MateriaViewModel materiaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (materiaViewModel.NOME == null)
                {
                    ModelState.AddModelError("NOME", "O campo Materia deve ser preenchido!");
                }
                else
                {
                    MATERIA mATERIA = new MATERIA();
                    db.MATERIA.Add(mATERIA);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(materiaViewModel);
        }

        // GET: MATERIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return HttpNotFound();
            }
            return View(mATERIA);
        }

        // POST: MATERIA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_MATERIA,NOME")] MATERIA mATERIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATERIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mATERIA);
        }

        // GET: MATERIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return HttpNotFound();
            }
            return View(mATERIA);
        }

        // POST: MATERIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MATERIA mATERIA = db.MATERIA.Find(id);
            db.MATERIA.Remove(mATERIA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
