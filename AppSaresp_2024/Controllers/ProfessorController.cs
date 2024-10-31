using Microsoft.AspNetCore.Mvc;
using AppSaresp_2024.Repository.Contract;
using AppSaresp_2024.Models;

namespace AppSaresp_2024.Controllers
{
    public class ProfessorController : Controller
    {
        private IProfessorRepository _professorRepository;
        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProfessor(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _professorRepository.Cadastrar(professor);
            }
            return View();
        }

        public IActionResult Index()
        {
            return View(_professorRepository.ObterTodosProfessores());
        }

        public IActionResult ExcluirProfessor(int id)
        {
            _professorRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
