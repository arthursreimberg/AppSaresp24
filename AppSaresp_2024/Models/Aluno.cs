using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AppSaresp_2024.Models
{
    public class Aluno
    {
        [Display(Name = "RA")]
        public int? RA { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string NomeAluno { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O Telefone deve conter exatamente 11 dígitos numéricos.")]
        public BigInteger Telefone { get; set; }

        [Display(Name = "Serie")]
        [Required(ErrorMessage = "A Série é obrigatório.")]
        public string Serie { get; set; }

        [Display(Name = "Turma")]
        [Required(ErrorMessage = "A Turma é obrigatório.")]
        public string Turma { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "O campo Nascimento é obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime DataNascAluno { get; set; }
    }
}
