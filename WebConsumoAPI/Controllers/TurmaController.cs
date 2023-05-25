using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurma _ITurma;
        public TurmaController(ITurma ITurma)
        {
            _ITurma = ITurma;
        }
        // GET: TurmaController
        public ActionResult Index()
        {
            try
            {
                return View(_ITurma.BuscaAllTurmas());
            }
            catch
            {
                return View();
            }
            
        }

        // GET: TurmaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_ITurma.BuscaTurmaByID(id));
        }

        // GET: TurmaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TurmaModel collection)
        {
            try
            {             
                string respota = _ITurma.AdicionaTurma(collection);
                TempData["mensagemErro"] = respota;
                return View(_ITurma.BuscaTurmaByID(collection.id));
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurmaController/Edit/5
        public ActionResult Edit(int id)
        {          
            
            return View(_ITurma.BuscaTurmaByID(id));
        }

        // POST: TurmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TurmaModel collection)
        {
            try
            {
                string respota = _ITurma.AtualizarTurma(collection, id);
                TempData["mensagemErro"] = respota;
                //_ITurma.BuscaTurmaByID(id);
                return View(_ITurma.BuscaTurmaByID(id));
            }
            catch
            {
                TempData["mensagemErro"] = "Algo deu errado!";
                return Index();
            }
            
        }

        // GET: TurmaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ITurma.BuscaTurmaByID(id));
        }

        // POST: TurmaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TurmaModel collection)
        {
            try
            {
                _ITurma.DeletarTurma(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
