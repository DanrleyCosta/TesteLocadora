using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWebApi.Dominio
{
    // Notas do Teste: Criei propriedades bem simples para facilitar o desenvolvimento
    public class Cliente
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public decimal Saldo { get; set; }
        public virtual ICollection<Locacao> Locacoes { get; set; }

        public decimal ValorAcrescimo = decimal.Zero;
    }
}
