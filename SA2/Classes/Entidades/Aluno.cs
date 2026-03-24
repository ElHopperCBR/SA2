using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA2.Classes.Entidades
{
    public class Aluno : User
    {
        [Required]
        public int RegistroAluno { get; set; }

        [Required]
        public int CursoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusWifi { get; set; } = "Inativo"; // Ativo ou Inativo

        [Required]
        [MaxLength(50)]
        public string StatusAction { get; set; } = "Aguardando aprovação"; // Aprovado, Aguardando aprovação, Reprovado
        
        // As propriedades Id, Nome e Regra são herdadas da classe User
    }
}
