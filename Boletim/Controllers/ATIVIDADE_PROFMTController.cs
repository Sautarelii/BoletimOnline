using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Boletim;
using Boletim.Models;

namespace Boletim.Controllers
{
    public class ATIVIDADE_PROFMTController : Controller
    {
        private BoletimOnline2Entities7 db = new BoletimOnline2Entities7();

        // GET: ATIVIDADE_PROFMT
        public ActionResult Index(int CodProf, int CodMateria,int CodTurma)
        {
            var Materia = db.MATERIA.Where(m => m.COD_MATERIA == CodMateria).FirstOrDefault();

            ViewBag.Materia = Materia;
            var Professor = db.PROFESSOR.Where(m => m.COD_PROF == CodProf).FirstOrDefault();
            ViewBag.Professor = Professor;
            var Turma = db.TURMA.Where(m => m.COD_TURMA == CodTurma).FirstOrDefault();
            ViewBag.Turma = Turma;

            var user = (ClaimsIdentity)User.Identity;
            var UsuarioId =
                Convert.ToInt32(
                user
                .Claims
                .Where(
                      u => u.Type == ClaimTypes.Sid)
                .FirstOrDefault()
                .Value);
            var aTIVIDADE_PROFMT =
                db.ATIVIDADE_PROFMT
                    .Include(a => a.ATIVIDADE)
                    .Include(a => a.MATERIA)
                    .Include(a => a.PROFESSOR)
                    .Include(a => a.TURMA)
                    .Where(a => a.PROFESSOR.COD_PROF == CodProf)
                    .Where(a => a.MATERIA.COD_MATERIA == CodMateria)
                    .Where(a => a.TURMA.COD_TURMA == CodTurma);
               

            //var aTIVIDADE_PROFMT = 
            //    db.ATIVIDADE_PROFMT
            //        .Include(a => a.ATIVIDADE)
            //        .Include(a => a.MATERIA)
            //        .Include(a => a.PROFESSOR)
            //        .Include(a => a.TURMA)
            //        .Where(a => a.PROFESSOR.UsuarioId == UsuarioId);
            //  var  _PROFMATERIATURMA =
            //     db.
            return View(aTIVIDADE_PROFMT.ToList());
        }

        // GET: ATIVIDADE_PROFMT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATIVIDADE_PROFMT aTIVIDADE_PROFMT = db.ATIVIDADE_PROFMT.Find(id);
            if (aTIVIDADE_PROFMT == null)
            {
                return HttpNotFound();
            }
            return View(aTIVIDADE_PROFMT);
        }

        // GET: ATIVIDADE_PROFMT/Create
        public ActionResult Create()
        {
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE");
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME");
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME");
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE");
            return View();
        }

        // POST: ATIVIDADE_PROFMT/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ATIVIDADE,NOME_ATIVIDADE,DATA_ENTREGA,TIPO_ATIVIDADE,COD_MATERIA,COD_TURMA,PERIODO_LETIVO")]  Atividade_ProfmtViewModel atividade_ProfmtViewModel)
        {
            if (ModelState.IsValid)
            {
                //CRIAR OBJETO ATIVIDADE 
                ATIVIDADE atividade = new ATIVIDADE();
                //INSERIR O PROXIMO DADOS 
                atividade.NOME_ATIVIDADE  = atividade_ProfmtViewModel.NOME_ATIVIDADE;
                atividade.DATA_ENTREGA = atividade_ProfmtViewModel.DATA_ENTREGA;
                atividade.TIPO_ATIVIDADE = atividade_ProfmtViewModel.TIPO_ATIVIDADE;
                atividade.COD_MATERIA = atividade_ProfmtViewModel.COD_MATERIA;


                db.ATIVIDADE.Add(atividade);
                db.SaveChanges();
               
                ATIVIDADE_PROFMT aTIVIDADE_PROFMT = new ATIVIDADE_PROFMT();
                aTIVIDADE_PROFMT.COD_ATIVIDADE = db.ATIVIDADE.Max(row => row.COD_ATIVIDADE);
                aTIVIDADE_PROFMT.COD_MATERIA = atividade_ProfmtViewModel.COD_MATERIA;
                aTIVIDADE_PROFMT.COD_TURMA = atividade_ProfmtViewModel.COD_TURMA;
                aTIVIDADE_PROFMT.PERIODO_LETIVO = atividade_ProfmtViewModel.PERIODO_LETIVO;


                var user = (ClaimsIdentity)User.Identity;
                var UsuarioId =
                    Convert.ToInt32(
                    user
                    .Claims
                    .Where(
                          u => u.Type == ClaimTypes.Sid)
                    .FirstOrDefault()
                    .Value);
               

              
                var PROFESSOR =
                    db.PROFESSOR
                    .Where(a => a.UsuarioId == UsuarioId).FirstOrDefault();
                aTIVIDADE_PROFMT.COD_PROF = PROFESSOR.COD_PROF;
                db.ATIVIDADE_PROFMT.Add(aTIVIDADE_PROFMT);
                db.SaveChanges();
                String link = "Index/" + PROFESSOR.COD_PROF + "/" + atividade_ProfmtViewModel.COD_MATERIA + "/" + atividade_ProfmtViewModel.COD_TURMA;
                return RedirectToAction(link);
            }

            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "NOME_ATIVIDADE", "NOME_ATIVIDADE", atividade_ProfmtViewModel.NOME_ATIVIDADE);
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "DATA_ENTREGA", "DATA_ENTREGA", atividade_ProfmtViewModel.DATA_ENTREGA);
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "TIPO_ATIVIDADE", "TIPO_ATIVIDADE", atividade_ProfmtViewModel.TIPO_ATIVIDADE);
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", atividade_ProfmtViewModel.COD_MATERIA);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", atividade_ProfmtViewModel.COD_TURMA);
            return View(atividade_ProfmtViewModel);
        }

        // GET: ATIVIDADE_PROFMT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATIVIDADE_PROFMT aTIVIDADE_PROFMT = db.ATIVIDADE_PROFMT.Find(id);
            if (aTIVIDADE_PROFMT == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE", aTIVIDADE_PROFMT.COD_ATIVIDADE);
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", aTIVIDADE_PROFMT.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME", aTIVIDADE_PROFMT.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", aTIVIDADE_PROFMT.COD_TURMA);
            return View(aTIVIDADE_PROFMT);
        }

        // POST: ATIVIDADE_PROFMT/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ATIVIDADE,COD_PROF,COD_MATERIA,COD_TURMA,PERIODO_LETIVO")] ATIVIDADE_PROFMT aTIVIDADE_PROFMT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTIVIDADE_PROFMT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_ATIVIDADE = new SelectList(db.ATIVIDADE, "COD_ATIVIDADE", "NOME_ATIVIDADE", aTIVIDADE_PROFMT.COD_ATIVIDADE);
            ViewBag.COD_MATERIA = new SelectList(db.MATERIA, "COD_MATERIA", "NOME", aTIVIDADE_PROFMT.COD_MATERIA);
            ViewBag.COD_PROF = new SelectList(db.PROFESSOR, "COD_PROF", "NOME", aTIVIDADE_PROFMT.COD_PROF);
            ViewBag.COD_TURMA = new SelectList(db.TURMA, "COD_TURMA", "SERIE", aTIVIDADE_PROFMT.COD_TURMA);
            return View(aTIVIDADE_PROFMT);
        }

        // GET: ATIVIDADE_PROFMT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATIVIDADE_PROFMT aTIVIDADE_PROFMT = db.ATIVIDADE_PROFMT.Find(id);
            if (aTIVIDADE_PROFMT == null)
            {
                return HttpNotFound();
            }
            return View(aTIVIDADE_PROFMT);
        }

        // POST: ATIVIDADE_PROFMT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATIVIDADE_PROFMT aTIVIDADE_PROFMT = db.ATIVIDADE_PROFMT.Find(id);
            db.ATIVIDADE_PROFMT.Remove(aTIVIDADE_PROFMT);
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
