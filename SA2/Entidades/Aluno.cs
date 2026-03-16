using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA2.Entidades
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string NomeDoAluno { get; set; } = string.Empty;

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
    }
}
