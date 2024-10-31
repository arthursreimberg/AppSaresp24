using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _conexaoMySQL;

        public AlunoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into aluno(RA, Nome, Email, Telefone, Serie, Turma, DataNascimento)" +
                                                              "values (@RA, @NomeAluno, @Email, @Telefone, @Serie, @Turma, @DataNascAluno)", conexao);

                cmd.Parameters.Add("@RA", MySqlDbType.VarChar).Value = aluno.RA;
                cmd.Parameters.Add("@NomeAluno", MySqlDbType.VarChar).Value = aluno.NomeAluno;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = aluno.Telefone;
                cmd.Parameters.Add("@Serie", MySqlDbType.VarChar).Value = aluno.Serie;
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@DataNascAluno", MySqlDbType.Datetime).Value = aluno.DataNascAluno.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
                
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from aluno where RA=@RA", conexao);
                cmd.Parameters.AddWithValue("@RA", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Aluno ObterAluno(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from aluno" + " where RA=@RA", conexao);
                cmd.Parameters.AddWithValue("@RA", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Aluno aluno = new Aluno();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    aluno.RA = Convert.ToInt32(dr["RA"]);
                    aluno.NomeAluno = (string)dr["Nome"];
                    aluno.Email = (string)dr["Email"];
                    aluno.Telefone = Convert.ToInt64(dr["Telefone"]);
                    aluno.Serie = (string)dr["Serie"];
                    aluno.Turma = (string)dr["Turma"];
                    aluno.DataNascAluno = Convert.ToDateTime(dr["DataNascimento"]);
                }
                return aluno;
            }
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            List<Aluno> AlunoList = new List<Aluno>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from aluno", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    AlunoList.Add(
                     new Aluno
                     {
                         RA = Convert.ToInt32(dr["RA"]),
                         NomeAluno = (string)dr["Nome"],
                         Email = (string)dr["Email"],
                         Telefone = Convert.ToInt64(dr["Telefone"]),
                         Serie = (string)dr["Serie"],
                         Turma = (string)dr["Turma"],
                         DataNascAluno = Convert.ToDateTime(dr["DataNascimento"])

                     });
                }
                return AlunoList;
            }
        }
    }
}
