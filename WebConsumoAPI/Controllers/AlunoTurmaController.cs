using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Controllers
{
    public class AlunoTurmaController : Controller
    {
        private readonly IAlunoTurma _IAlunoTurma; 
        private readonly ITurma _ITurma;
        private readonly IAluno _IAluno;
        public AlunoTurmaController(IAlunoTurma IAlunoTurma, IAluno IAluno, ITurma ITurma)
        {
            _IAlunoTurma = IAlunoTurma;
            _IAluno = IAluno;
            _ITurma = ITurma;
        }

        // GET: AlunoTurmaController1
        public ActionResult Index()
        {
            try {
                return View(_IAlunoTurma.BuscaAlunosTurmaAsync());
            }
            catch
            {
                return View();
            }
            
        }

        // GET: AlunoTurmaController1/Details/5
        public ActionResult Details(int id)
        {
            //IEnumerable<AlunoTurmaModel> teste = _IAlunoTurma.BuscaAlunoTurmaByAluno(id);
            return View(_IAlunoTurma.BuscaAlunoTurmaByAluno(id));
        }

        // GET: AlunoTurmaController1/Create
        public ActionResult Create()
        {
            //var alunos = _IAluno.BuscaAlunosAsync();
            
            ViewBag.Turmas = _ITurma.BuscaAllTurmas();
            ViewBag.Alunos = _IAluno.BuscaAlunosAsync();
            
            
            return View();
        }

        // POST: AlunoTurmaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoTurmaModel collection)
        {
            try
            {
                var resposta = _IAlunoTurma.AdicionaAsync(collection);               
                TempData["mensagemErro"] = resposta;
                ViewBag.Turmas = _ITurma.BuscaAllTurmas();
                ViewBag.Alunos = _IAluno.BuscaAlunosAsync();
                return View();              
               
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }       
        

        // GET: AlunoTurmaController1/Delete/5
        public ActionResult Delete(int turma_id, int aluno_id)
        {
            return View(_IAlunoTurma.BuscaAlunoTurmaCompleto(turma_id, aluno_id)); 
        }

        // POST: AlunoTurmaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int turma_id, int aluno_id, AlunoTurmaModel collection)
        {
            try
            {
                _IAlunoTurma.DeletarAsync(collection.turma_id, collection.aluno_id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
