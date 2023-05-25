using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAluno _IAluno;
        public AlunosController(IAluno IAluno)
        {
            _IAluno = IAluno;
        }
        // GET: AlunosController
        public ActionResult Index()
        {
            try
            {
                return View(_IAluno.BuscaAlunosAsync());
            }
            catch
            {
                return View();
            }
            
        }

        // GET: AlunosController/Details/5
        public ActionResult Details(int id)
        {
            return View(_IAluno.BuscaAlunoAsync(id));
        }

        // GET: AlunosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoModel collection)
        {
            try
            {
                if (collection.senha == null) collection.senha = "";
                string respota = _IAluno.AdicionaAsync(collection);
                TempData["mensagemErro"] = respota;
                return View(_IAluno.BuscaAlunoAsync(collection.id));
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_IAluno.BuscaAlunoAsync(id));
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlunoModel collection)
        {
            try
            {
                if (collection.nome == null) collection.nome = "";
                if (collection.usuario == null) collection.usuario = "";
                if (collection.senha == null) collection.senha = "";

                string respota = _IAluno.AtualizarAsync(collection, id);
                TempData["mensagemErro"] = respota;
                
                return View(_IAluno.BuscaAlunoAsync(id)); 
            }
            catch
            {
                TempData["mensagemErro"] = "Algo deu errado!";
                return Index();
            }
        }

        // GET: AlunosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_IAluno.BuscaAlunoAsync(id));
        }

        // POST: AlunosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AlunoModel aluno)
        {
            try
            {
                _IAluno.DeletarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
