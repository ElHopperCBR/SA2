using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SA2.Classes.Entidades.Enumeracoes;

namespace SA2.Classes.Entidades
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [MinLength(6)]
        public string Senha { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [NotMapped] // Isso faz o Entity Framework ignorar esta propriedade
        public TipoRegra Regra { get; set; } = TipoRegra.Usuario;
    }
}
