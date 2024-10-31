using AppSaresp_2024.Models;

namespace AppSaresp_2024.Repository.Contract
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> ObterTodosProfessores();

        void Cadastrar(Professor professor);


        Professor ObterProfessor (int Id);

        void Excluir(int id);
    }
}
