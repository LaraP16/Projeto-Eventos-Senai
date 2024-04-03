using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models
{
    public class Evento
    {
        [Column("idevento")]
        public int IdEvento { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("total_ingresso")]
        public decimal TotalIngresso { get; set; }

        [Column("data_evento")]
        public DateTime DataEvento { get; set; }

        [Column("imagem_url")]
        public string? ImagemUrl { get; set; }

         [Column("local")]
        public string? Local { get; set; }

        [Column("ativo")]
        public int Ativo { get; set; }

      
    }
}
