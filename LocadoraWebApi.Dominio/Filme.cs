using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWebApi.Dominio
{
    public class Filme
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Creditos { get; set; }
        public virtual ICollection<Locacao> Locacoes { get; set; }
    }
}
