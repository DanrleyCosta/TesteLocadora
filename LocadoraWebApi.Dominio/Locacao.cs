using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWebApi.Dominio
{
    public class Locacao
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLocacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataDevolucao { get; set; }
        [Required]
        [UIHint("FilmeDropDownList")]
        [Display(Name = "Filme")]
        public int FId { get; set; }
        [JsonIgnore]
        public virtual Filme Filme { get; set; }
        [Required]
        [UIHint("ClienteDropDownList")]
        [Display(Name = "Cliente")]
        public int CId { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }

        public bool PossuiCreditos()
        {
            if (this.Cliente.Saldo >= this.Filme.Creditos)
            {
                this.Cliente.Saldo -= this.Filme.Creditos;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
