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
    public class ALUNO_ATIVIDADEController : Controller
    {
        private BoletimOnline2Entities7 db = new BoletimOnline2Entities7();

        // GET: ALUNO_ATIVIDADE
        public ActionResult Index()
        {
            var aLUNO_ATIVIDADE = db.ALUNO_ATIVIDADE.Include(a => a.ALUNO).Include(a => a.ATIVIDADE);
            return View(aLUNO_ATIVIDADE.ToList());
        }

        // GET: ALUNO_ATIVIDADE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO_ATIVIDADE aLUNO_ATIVIDADE = db.ALUNO_ATIVIDADE.Find(id);
            if (aLUNO_ATIVIDADE == null)
            {
                return HttpNotFound();
            }
            return View(aLUNO_ATIVIDADE);
        }

        // GET: ALUNO_ATIVIDADE/Create
        public ActionResult Create()
        {
            ViewBag.COD_ALUNO = new SelectList(db.ALUNO, "COD_ALUNO", "NOME");
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE");
            return View();
        }

        // POST: ALUNO_ATIVIDADE/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ALUNO,COD_ATIVIDADE,NOTA")] ALUNO_ATIVIDADE aLUNO_ATIVIDADE)
        {
            if (ModelState.IsValid)
            {
                db.ALUNO_ATIVIDADE.Add(aLUNO_ATIVIDADE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_ALUNO = new SelectList(db.ALUNO, "COD_ALUNO", "NOME", aLUNO_ATIVIDADE.COD_ALUNO);
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE", aLUNO_ATIVIDADE.COD_ATIVIDADE);
            return View(aLUNO_ATIVIDADE);
        }

        // GET: ALUNO_ATIVIDADE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO_ATIVIDADE aLUNO_ATIVIDADE = db.ALUNO_ATIVIDADE.Find(id);
            if (aLUNO_ATIVIDADE == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_ALUNO = new SelectList(db.ALUNO, "COD_ALUNO", "NOME", aLUNO_ATIVIDADE.COD_ALUNO);
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE", aLUNO_ATIVIDADE.COD_ATIVIDADE);
            return View(aLUNO_ATIVIDADE);
        }

        // POST: ALUNO_ATIVIDADE/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ALUNO,COD_ATIVIDADE,NOTA")] ALUNO_ATIVIDADE aLUNO_ATIVIDADE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUNO_ATIVIDADE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_ALUNO = new SelectList(db.ALUNO, "COD_ALUNO", "NOME", aLUNO_ATIVIDADE.COD_ALUNO);
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE", aLUNO_ATIVIDADE.COD_ATIVIDADE);
            return View(aLUNO_ATIVIDADE);
        }

        // GET: ALUNO_ATIVIDADE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO_ATIVIDADE aLUNO_ATIVIDADE = db.ALUNO_ATIVIDADE.Find(id);
            if (aLUNO_ATIVIDADE == null)
            {
                return HttpNotFound();
            }
            return View(aLUNO_ATIVIDADE);
        }

        // POST: ALUNO_ATIVIDADE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUNO_ATIVIDADE aLUNO_ATIVIDADE = db.ALUNO_ATIVIDADE.Find(id);
            db.ALUNO_ATIVIDADE.Remove(aLUNO_ATIVIDADE);
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
