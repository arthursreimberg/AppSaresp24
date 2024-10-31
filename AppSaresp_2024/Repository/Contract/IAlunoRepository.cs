using AppSaresp_2024.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System.Data;

namespace AppSaresp_2024.Repository.Contract
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> ObterTodosAlunos();

        void Cadastrar(Aluno aluno);

        Aluno ObterAluno(int Id);

        void Excluir(int id);
    }
}
