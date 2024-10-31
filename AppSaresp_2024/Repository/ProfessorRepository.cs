using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly string _conexaoMySQL;

        public ProfessorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar(Professor professor)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into professorAplicador(Nome, CPF, RG, Telefone, DataNascimento)" +
                                                              "values (@NomeProfessor, @CPF, @RG, @TelefoneProf, @DataNascProfessor)", conexao);

             
                cmd.Parameters.Add("@NomeProfessor", MySqlDbType.VarChar).Value = professor.NomeProfessor;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = professor.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professor.RG;
                cmd.Parameters.Add("@TelefoneProf", MySqlDbType.VarChar).Value = professor.TelefoneProf;
                cmd.Parameters.Add("@DataNascProfessor", MySqlDbType.Datetime).Value = professor.DataNascProfessor.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }

        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from professor where IdProfessor=@IdProfessor", conexao);
                cmd.Parameters.AddWithValue("@IdProfessor", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Professor ObterProfessor(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from professorAplicador" + " where IdProfessor=@IdProfessor", conexao);
                cmd.Parameters.AddWithValue("@IdProfessor", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Professor professor= new Professor();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    professor.IdProfessor = Convert.ToInt32(dr["idProfessor"]);
                    professor.NomeProfessor = (string)dr["Nome"];
                    professor.CPF = (string)dr["CPF"];
                    professor.RG = (string)dr["RG"];
                    professor.TelefoneProf = Convert.ToInt64(dr["Telefone"]);
                    professor.DataNascProfessor = Convert.ToDateTime(dr["DataNascimento"]);
                }
                return professor;
            }
        }

        public IEnumerable<Professor> ObterTodosProfessores()
        {
            List<Professor> ProfessorList = new List<Professor>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from professorAplicador", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    ProfessorList.Add(
                     new Professor
                     {
                         IdProfessor = Convert.ToInt32(dr["IdProfessor"]),
                         NomeProfessor = (string)dr["Nome"],
                         CPF = (string)dr["CPF"],
                         RG = (string)dr["RG"],
                         TelefoneProf = Convert.ToInt64(dr["Telefone"]),
                         DataNascProfessor = Convert.ToDateTime(dr["DataNascimento"])

                     });
                }
                return ProfessorList;
            }
        }
    }
}
