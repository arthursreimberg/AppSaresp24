using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AppSaresp_2024.Models
{
    public class Professor
    {
        [Display(Name = "IdProfessor")]
        public int? IdProfessor { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string NomeProfessor { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter exatamente 11 dígitos numéricos.")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O RG é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O RG deve conter exatamente 9 dígitos numéricos.")]
        public string RG { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O Telefone deve conter exatamente 11 dígitos numéricos.")]
        public BigInteger TelefoneProf { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime DataNascProfessor { get; set; }
    }
}
