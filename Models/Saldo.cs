using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("saldo")]
    public class Saldo
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("produto_id")]
        public int IdProduto { get; set; }

        [Column("almoxarifado_id")]
        public int IdAlmoxarifado { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        public Saldo(int idProduto, int idAlmoxarifado, int quantidade)
        {
            IdProduto = idProduto;
            IdAlmoxarifado = idAlmoxarifado;
            Quantidade = quantidade;
        }

        public Saldo() { }
    }
}