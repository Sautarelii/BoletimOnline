using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boletim;

namespace Boletim.Controllers
{
    public class ATIVIDADEController : Controller
    {
        private BoletimOnline2Entities6 db = new BoletimOnline2Entities6();

       

        // GET: ATIVIDADE
        public ActionResult Index(string Pesquisa = "")
        {
            var q = db.ATIVIDADE.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa))
                q = q.Where(c => c.NOME_ATIVIDADE.Contains(Pesquisa));
            q = q.OrderBy(c => c.NOME_ATIVIDADE);


            return View(q.ToList());
        }
        
            

        

        // GET: ATIVIDADE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATIVIDADE aTIVIDADE = db.ATIVIDADE.Find(id);
            if (aTIVIDADE == null)
            {
                return HttpNotFound();
            }
            return View(aTIVIDADE);
        }

        // GET: ATIVIDADE/Create
        public ActionResult Create()
        {
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME");
            return View();
        }

        // POST: ATIVIDADE/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ATIVIDADE,NOME_ATIVIDADE,DATA_ENTREGA,TIPO_ATIVIDADE,COD_MATERIA")] ATIVIDADE aTIVIDADE)
        {
            if (ModelState.IsValid)
            {
                db.ATIVIDADE.Add(aTIVIDADE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", aTIVIDADE.COD_MATERIA);
            return View(aTIVIDADE);
        }
       
        // GET: ATIVIDADE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATIVIDADE aTIVIDADE = db.ATIVIDADE.Find(id);
            if (aTIVIDADE == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", aTIVIDADE.COD_MATERIA);
            return View(aTIVIDADE);
        }

        // POST: ATIVIDADE/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ATIVIDADE,NOME_ATIVIDADE,DATA_ENTREGA,TIPO_ATIVIDADE,COD_MATERIA")] ATIVIDADE aTIVIDADE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTIVIDADE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", aTIVIDADE.COD_MATERIA);
            return View(aTIVIDADE);
        }

        // GET: ATIVIDADE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATIVIDADE aTIVIDADE = db.ATIVIDADE.Find(id);
            if (aTIVIDADE == null)
            {
                return HttpNotFound();
            }
            return View(aTIVIDADE);
        }

        // POST: ATIVIDADE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATIVIDADE aTIVIDADE = db.ATIVIDADE.Find(id);
            db.ATIVIDADE.Remove(aTIVIDADE);
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
