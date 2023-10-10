using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFarmacia.Model
{
    public class Produto : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Tarja { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Preco { get; set; } = string.Empty;
    }
}
